using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAmazonS3
{
    class Program
    {
        static void Main(string[] args)
        {
            s3Core clsCore = new s3Core();
            clsCore.DoUpload();
        }
    }
}
