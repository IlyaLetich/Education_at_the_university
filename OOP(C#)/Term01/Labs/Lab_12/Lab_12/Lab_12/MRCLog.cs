using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
    internal class MRCLog
    {
        int counterUpdate = 0;
        private readonly string patch;

        public MRCLog(string patch)
        {
            this.patch = patch;
        }
        public void WriteActionInFile(string messageUpdate)
        {
            using (StreamWriter sw = new StreamWriter(patch, true))
            {
                sw.WriteLine($"<><><><><><><><><><><><><> Action: {counterUpdate + 1} <><><><><><><><><><><><><>\n");
                sw.WriteLine($"Time Update: {DateTime.Now.ToString()}\n");
                sw.WriteLine(messageUpdate);
                sw.WriteLine($"\n<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><");
            }
            counterUpdate++;
        }
    }
}
