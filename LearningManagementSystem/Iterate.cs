using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    public class Iterate
    {
        private Teacher[] teachers = new Teacher[1];

        public Teacher this[int index]
        {
            get { return teachers[index]; }
            set { teachers[index] = value; }
        }

        public int possition = -1;

        public void Reset()
        {
            possition = -1;
        }

        public IEnumerator<Teacher> GetEnumerator()
        {
            while (true)
            {
                if(possition < teachers.Length - 1)
                {
                    possition++;
                    yield return teachers[possition];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }
    }
}
