﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS
{
    public partial class initializing : Form
    {
        CPUScheduler cpuScheduler;
        ArrayList processQueue;

        public initializing()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessEngine tempPE = cpuScheduler.getProcessEngine();
            tempPE.userSpecificGenerate();
            //still needs to edit
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void generateRandom_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ProcessEngine tempPE = cpuScheduler.getProcessEngine();
            processQueue = tempPE.randomProcessGenerate();

            for (int i = 0; i < processQueue.Count; i++) {
                string[] arr = new string[3];
                Process tempProcess = (Process)(processQueue[i]);
                arr[0] = (tempProcess.processID).ToString();
                arr[1] = tempProcess.arrivalTime.ToString();
                arr[2] = tempProcess.burstTime.ToString();

                ListViewItem itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
           

        }

        private void process_done_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0) {
                MessageBox.Show("Process Empty","Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                cpuScheduler.getDispatcher().setProcessQueue(processQueue);
                this.Hide();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            this.Hide();
        }

        public void setCPUScheduler(CPUScheduler cpuScheduler) {
            this.cpuScheduler = cpuScheduler;
        }
    }
}
