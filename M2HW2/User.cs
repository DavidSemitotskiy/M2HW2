using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class User
    {
        public User(string name, decimal money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; private set; }
        public decimal Money { get; private set; }
        public Guid IdUser { get; } = Guid.NewGuid();
        public void Pay(decimal money)
        {
            Money -= money;
        }
    }
}
