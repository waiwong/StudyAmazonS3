using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.Net;
using System.Net.Http;

namespace StudyAmazonS3
{
    public class s3Core
    {
        public void DoUpload()
        {
            string accessKey = "*** access Key ***";
            string secretKey = "*** secret Key ***";
            string bucketName = "*** bucket name ***";
            string uploadFileName = "*** upload FileName ***"; //e.g. test.xml
            string downloadFileName = "*** download FileName ***";//e.g. test.png

            AmazonS3Config s3Config = new AmazonS3Config
            {
                ServiceURL = "s3.amazonaws.com",
                RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1
            };

            //ServicePointManager.ServerCertificateValidationCallback = (s, c, ch, ssl) =>
            //{
            //    Console.WriteLine("Got callback");
            //    return true;
            //};

            BasicAWSCredentials basicAWSCredentials = new BasicAWSCredentials(accessKey, secretKey);
            AmazonS3Client client = new AmazonS3Client(basicAWSCredentials, s3Config);
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    string appDir = AppDomain.CurrentDomain.BaseDirectory;
                    TransferUtility fileTransUtil = new TransferUtility(client);
                    if (i == 0)
                        fileTransUtil.Upload(Path.Combine(appDir, uploadFileName), bucketName, uploadFileName);
                    else
                        fileTransUtil.Download(Path.Combine(appDir, downloadFileName), bucketName, downloadFileName);
                }
                catch (AmazonS3Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Amazon error code:{0}", e.ErrorCode ?? "None"));
                    System.Diagnostics.Debug.Write(e.ToString());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(ex.ToString());
                }
            }
        }
    }
}
