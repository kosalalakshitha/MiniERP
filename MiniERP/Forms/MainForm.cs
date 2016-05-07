using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniERP.Classes;

namespace MiniERP.Forms
{
    public partial class MainForm : Form
    {
        private static ListBox openWindowList;
        private int windowCount = 0;
        public static bool isSuperUser;
        public static string userName;

        public MainForm()
        {
            InitializeComponent();
            lblStatus.Text = "System Loading...";
            this.IsMdiContainer = true;
            createListView();
            lblStatus.Text = "System Ready...";
            splitContainer3.FixedPanel = FixedPanel.Panel2;
            splitContainer3.IsSplitterFixed = true;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
        }

        private void createListView()
        {
            ContextMenu rmbMenu = new ContextMenu();
            MenuItem closeMenuItem = new MenuItem("Close");
            closeMenuItem.Click += CloseMenuItem_Click;
            rmbMenu.MenuItems.Add(closeMenuItem);
            openWindowList = new ListBox();
            openWindowList.Dock = DockStyle.Fill;
            openWindowList.SelectedIndexChanged += openWindowList_SelectedIndexChanged;
            openWindowList.ContextMenu = rmbMenu;
            splitContainer2.Panel2.Controls.Add(openWindowList);
            openWindowList.Items.Clear();
            openWindowList.DisplayMember = "windowName";
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (openWindowList.SelectedItem != null)
            {
                ListBoxItem item = (ListBoxItem)openWindowList.SelectedItem;
                item.bindWindow.Dispose();
                openWindowList.Items.Remove(openWindowList.SelectedItem);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Form window;
            ListBoxItem item;

            if (treeView1.SelectedNode == null)
            {
                return;
            }

            switch (treeView1.SelectedNode.Name)
            {
                case "custOrder":
                    window = new CustomerOrder(windowCount);
                    break;
                case "part":
                    window = new PartDetails(windowCount);
                    break;
                case "catagory":
                    window = new Category(windowCount);
                    break;
                case "customer":
                    window = new CustomerDetail(windowCount);
                    break;
                case "administration":
                    window = new Administration(windowCount, isSuperUser);
                    break;
                case "purchOrder":
                    window = new PurchaseOrder(windowCount);
                    break;

                default:
                    window = new Form();
                    return;
            }

            window.TopLevel = false;
            window.AutoScroll = true;

            item = new ListBoxItem(treeView1.SelectedNode.Text, window, windowCount);
            openWindowList.Items.Add(item);
            windowCount++;
            splitContainer3.Panel1.Controls.Add(item.bindWindow);
            item.bindWindow.Show();
            item.bindWindow.BringToFront();

            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void openWindowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxItem item = (ListBoxItem)openWindowList.SelectedItem;
            if (item != null)
            {
                item.bindWindow.BringToFront();
                lblStatus.Text = item.bindWindow.Text;
            }
        }

        public static void childClosed(int windowCount)
        {
            foreach (ListBoxItem item in openWindowList.Items)
            {
                if (item.windowCount == windowCount)
                {
                    openWindowList.Items.Remove(item);
                    break;
                }
            }
        }
    }
}
