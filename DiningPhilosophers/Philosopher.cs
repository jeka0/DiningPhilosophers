using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace DiningPhilosophers
{
    public class Philosopher
    {
        public static Form1 form;
        public static Mutex[] mutices = new Mutex[5];
        private static int[] counts = new int[5];
        private int id, index;
        private static Random random = new Random();
        public Philosopher(int id)
        { 
            this.id = id;
            if (id == 0) index = 4; else index = id - 1;
            for (int i = 0; i < 5; i++) mutices[i] = new Mutex();
        }
        public void Start()
        {
            bool flag = true;
            int nowId = id,nowIndex = index;
            if (nowId%2!=0) 
            {
                int buf = nowId;
                nowId = nowIndex;
                nowIndex = buf;
            }
            while(true)
            {
                for (int i = 0; i < 5; i++) if (id != i && (counts[id] - counts[i]) > 3) flag = false;
                if (flag)
                {
                    form.SetColorPhilosopher0(id, Color.Red);
                    mutices[nowId].WaitOne();
                    form.SetIdFork(nowId, id + 1);
                    mutices[nowIndex].WaitOne();
                    form.SetIdFork(nowIndex, id + 1);

                    form.SetColorPhilosopher0(id, Color.Green);
                    form.SetCountId(id, ++counts[id]);
                    Thread.Sleep(2000);

                    form.SetIdFork(nowIndex, 0);
                    mutices[nowIndex].ReleaseMutex();
                    form.SetIdFork(nowId, 0);
                    mutices[nowId].ReleaseMutex();
                }
                form.SetColorPhilosopher0(id, Color.Yellow);
                Thread.Sleep(random.Next(1000, 4000));
                flag = true;
            }
        }
    }
}
