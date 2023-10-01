using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    [DataContractAttribute]
    internal class Warehouseman
    {
        [DataMember]
        internal string FIO;
        [DataMember]
        internal int Level;
        [DataMember]
        internal string Mail;

        public Warehouseman(string fio, int level, string mail)
        {
            FIO = fio;
            Level = level;
            Mail = mail;
        }

        public override string ToString()
        {
            return ($"FIO - {FIO}, Level - {Level}, Mail - {Mail}");
        }
    }
}
