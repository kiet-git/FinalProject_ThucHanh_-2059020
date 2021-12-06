using System.IO;
using System.Collections.Generic;

namespace ModuleSoanDe
{
    public class NormalTextExecuter
    {
        ProjectDirectory fd = new ProjectDirectory();

        public void write(List<EmTestQCollection> lstET, string filePath)
        {
            filePath = fd.getFolder("resultDir") + filePath;
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine($"Result of ITEC test: ");
                foreach (var em in lstET)
                {
                    sw.WriteLine($"Test Id: {em.Id} " +
                        $"| Month: {em.Month} | Year: {em.Year} " +
                        $"| EmID: {em.EmId} | EmName: {em.EmName} | EmEmail: {em.EmEmail} " +
                        $"| Mark: {em.Mark}");
                }
            }
        }
    }
}
