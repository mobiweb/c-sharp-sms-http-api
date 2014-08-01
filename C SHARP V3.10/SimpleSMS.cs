using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

//.---------------------------------------------------------------------------.
//|  Software: HTTP API - Simple Text SMS				              		  |
//|  Version: 	3.10														  |
//|  Email: 	support@solutions4mobiles.com								  |
//|  Info: 		http://www.solutions4mobiles.com							  |
//|  Phone:		+44 203 318 3618											  |
//| ------------------------------------------------------------------------- |
//| Copyright (c) 1999-2014, Mobiweb Ltd. All Rights Reserved.                |
//| ------------------------------------------------------------------------- |
//| LICENSE:																  |
//| Distributed under the General Public License v3 (GPLv3)					  |
//| http://www.gnu.org/licenses/gpl-3.0.html								  |
//| This program is distributed AS IS and in the hope that it will be useful  |
//| WITHOUT ANY WARRANTY; without even the implied warranty of				  |
//| MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.                      |
//| ------------------------------------------------------------------------- |
//| SERVICES:																  |
//| We offer a number of paid services at http//www.solutions4mobiles.com:    |
//| - Bulk SMS / MMS / Premium SMS Services	/ HLR Lookup Service			  |
//| ------------------------------------------------------------------------- |
//| HELP:																	  |
//| - This class requires a valid HTTP API Account. Please email to			  |
//| sales@solutions4mobiles.com to get one									  |
//.---------------------------------------------------------------------------.

// Send SMS Example: SMS with Delivery Report
// @copyright 1999 - 2014 Mobiweb Ltd.--%>

namespace MobiWeb
{
    class SimpleSMS
    {
        static void Main(string[] args)
        {
            String url = "http://IPADDRESS/send_script";             			//The SMS HTTP API send url.
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url);   //Create object of class required for POST request.
                                                                                //Initialize post object.

            ASCIIEncoding encoding = new ASCIIEncoding();

            string postData = "username=username";                              //The HTTP API username of your account.
            postData += "&password=password";                                   //The HTTP API password of your account.
            postData += "&msgtext=Hello World";                                 //The SMS Message text.
            postData += "&originator=TestAccount";                              //The desired Originator of your message.
            postData += "&phone=recipient";                                     //The full International mobile number of the
                                                                                //recipient excluding the leeding +.
            postData += "&showDLR=0";                                           //Set to 1 for requesting delivery report 
        																        //of this sms. A unique id is returned to use																								
        																        //with your delivery report request.
            postData += "&charset=0";                                           //The SMS Message text Charset.
            postData += "&msgtype=";                                            //If set to F the sms is sent as Flash.
            postData += "&smsprovider=solutions4mobiles.com";                   //The SMS Provider.

            byte[] data = encoding.GetBytes(postData);

            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;

            																	//Write parameters to POST request and send it.

            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }


            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

            																	//Get Response

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            System.Diagnostics.Debug.Print(responseString);
        }
    }
}
