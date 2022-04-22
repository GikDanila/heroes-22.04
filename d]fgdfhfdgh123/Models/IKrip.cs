using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d_fgdfhfdgh123.Models
{
   
    
        public interface IKrip
        {
            void UpdateStat(int damage, int hp);
            int Storming();
            void LossOfHealth(int damage);
            bool IsDead();

            int GetHp();
        }
    

}

