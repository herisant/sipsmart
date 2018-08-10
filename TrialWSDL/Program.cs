using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TrialWSDL
{
    class Program
    {
        static void Main()
        {
            try
            {
        //        ReadFIle();
                

                Execute();
                //Console.WriteLine("MASUK 1");
                //test.downloadSiswaGuru online = new test.downloadSiswaGuru();
                //Console.WriteLine("MASUK 2");
                //var data = online.getData("1");
                //Console.WriteLine(data);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }


        
        static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://www.siponline.id/apps/main/index.php/Service/downloadsiswaguru?wsdl");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        static void Execute()
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            //soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
            //<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
            //<soap:Body>
            //<HelloWorld3 xmlns=""http://tempuri.org/"">
            //<parameter1>test</parameter1>
            //<parameter2>23</parameter2>
            //<parameter3>test</parameter3>
            //</HelloWorld3>
            //</soap:Body>
            //</soap:Envelope>");

            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:downloadSiswaGuru"">
            <soapenv:Body>
            <urn:getData soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">
            <sekolah_id xsi:type=""xsd:string"">1</sekolah_id>
            </urn:getData>
            </soapenv:Body>
            </soapenv:Envelope>");
            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }




            //var text = from result in soapEnvelopeXml

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {




                    string[] data = rd.ReadToEnd().Split('{');

                    //string soapResult = rd.ReadToEnd().Replace("&quot", "").Replace(";", "\"");
                    Console.WriteLine(rd.ReadToEnd());
                    Console.ReadKey();
                }
            }
        }
    }
}
