﻿namespace EventsSystem.WindowsFormsClient
{
    using Forms.Accounts;
    using Forms;
    using Forms.Event;
    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private readonly string DEFAULT_STATUS_LABEL = "Ready";
        private readonly string DEFAULT_STATUS_PATTERN = "Client: {0}.";

        private bool isLogged = false;

        private eventForm eventForm = null;
        private InsertEventForm insertForm = null;
        private loginForm loginView = null;
        private CreateForm createForm = null;

        public MainForm()
        {
            this.InitializeComponent();
        }

        public void Initialize()
        {
            this.StatusLabel = string.Format(this.DEFAULT_STATUS_PATTERN, this.DEFAULT_STATUS_LABEL);
            this.ToggleControls();
        }

        private void ToggleControls()
        {
            this.eventsToolStripMenuItem.Enabled = this.isLogged;
            this.modifyToolStripMenuItem.Enabled = this.isLogged;
            this.deleteToolStripMenuItem.Enabled = this.isLogged;
        }

        public string StatusLabel
        {
            get { return this.status_strip_label.Text; }
            set { this.status_strip_label.Text = string.Format(this.DEFAULT_STATUS_PATTERN, value); }
        }

        public bool SetAvailability
        {
            get { return this.isLogged; }
            set {
                this.isLogged = value;
                this.ToggleControls();
            }
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.eventForm == null)
            {
                this.eventForm = new eventForm();
                this.eventForm.MdiParent = this;
                this.eventForm.FormClosed += new FormClosedEventHandler(this.eventForm_FormClosed);
                this.eventForm.Show();
            }
            else
            {
                this.eventForm.Activate();
            }
        }

        private void eventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.eventForm = null;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.loginView == null)
            {
                this.loginView = new loginForm();
                this.loginView.MdiParent = this;
                this.loginView.FormClosed += new FormClosedEventHandler(this.loginForm_FormClosed);
                this.loginView.Show();
            }
            else
            {
                this.eventForm.Activate();
            }
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.loginView = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.insertForm == null)
            {
                this.insertForm = new InsertEventForm();
                this.insertForm.MdiParent = this;
                this.insertForm.FormClosed += new FormClosedEventHandler(this.insertForm_FormClosed);
                this.insertForm.Show();
            }
            else
            {
                this.insertForm.Activate();
            }
        }

        private void insertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.insertForm = null;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.createForm == null)
            {
                this.createForm = new CreateForm();
                this.createForm.MdiParent = this;
                this.createForm.FormClosed += new FormClosedEventHandler(this.createForm_FormClosed);
                this.createForm.Show();
            }
            else
            {
                this.insertForm.Activate();
            }
        }

        private void createForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.createForm = null;
        }
    }
}