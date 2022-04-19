using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DiningPhilosophers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Thread> threads = new List<Thread>();
        public void SetColorPhilosopher0(int id, Color color)
        {
            switch (id)
            {
                case 0: Philosopher0.Invoke(new Action(() => { Philosopher0.BackColor = color; })); break;
                case 1: Philosopher1.Invoke(new Action(() => { Philosopher1.BackColor = color; })); break;
                case 2: Philosopher2.Invoke(new Action(() => { Philosopher2.BackColor = color; })); break;
                case 3: Philosopher3.Invoke(new Action(() => { Philosopher3.BackColor = color; })); break;
                case 4: Philosopher4.Invoke(new Action(() => { Philosopher4.BackColor = color; })); break;
            }
        }
        public void SetCountId(int id, int count)
        {
            switch (id)
            {
                case 0: label1.Invoke(new Action(() => { label1.Text = "Количество: " + count.ToString(); })); break;
                case 1: label2.Invoke(new Action(() => { label2.Text = "Количество: " + count.ToString(); })); break;
                case 2: label3.Invoke(new Action(() => { label3.Text = "Количество: " + count.ToString(); })); break;
                case 3: label4.Invoke(new Action(() => { label4.Text = "Количество: " + count.ToString(); })); break;
                case 4: label5.Invoke(new Action(() => { label5.Text = "Количество: " + count.ToString(); })); break;
            }
        }
        public void SetIdFork(int forkid, int id)
        {
            switch (forkid)
            {
                case 0: Fork0.Invoke(new Action(() => { Fork0.Text = id.ToString(); })); break;
                case 1: Fork1.Invoke(new Action(() => { Fork1.Text = id.ToString(); })); break;
                case 2: Fork2.Invoke(new Action(() => { Fork2.Text = id.ToString(); })); break;
                case 3: Fork3.Invoke(new Action(() => { Fork3.Text = id.ToString(); })); break;
                case 4: Fork4.Invoke(new Action(() => { Fork4.Text = id.ToString(); })); break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0;i<5;i++)
            {
                Philosopher philosopher = new Philosopher(i);
                Thread thread = new Thread(philosopher.Start);
                threads.Add(thread);
                thread.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Mutex mutex in Philosopher.mutices) mutex.Dispose();
            foreach (Thread thread in threads) thread.Abort();
        }
    }
}
