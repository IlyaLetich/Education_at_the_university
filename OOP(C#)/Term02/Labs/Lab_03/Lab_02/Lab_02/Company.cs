using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    [DataContractAttribute]
    internal class Company
    {
        [DataMember]
        internal string Organization;
        [DataMember]
        internal string NumberTelefon;
        [DataMember]
        internal string Mail;
        [DataMember]
        internal string State;

        public Company(string organization, string numberTelefon, string mail, string state)
        {
            Organization = organization;
            NumberTelefon = numberTelefon;
            Mail = mail;
            State = state;
        }

        public override string ToString()
        {
            return ($"Organization - {Organization}, Telefon - {NumberTelefon}, Mail - {Mail}, State - {State}");
        }
    }
}
