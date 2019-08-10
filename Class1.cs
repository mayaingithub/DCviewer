﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Fiddler;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json.Linq;

[assembly: Fiddler.RequiredVersion("2.3.5.0")]

namespace DCviewer
{
    
    
    public class Violin : IAutoTamper    // Ensure class is public, or Fiddler won't see it!
    {
        string sUserAgent = "";
        ViewPanel oView;        
        public showErrorForm showErrorForm = new showErrorForm();


        //TabPage oPage = null;



        public Violin()
        {
            /* NOTE: It's possible that Fiddler UI isn't fully loaded yet, so don't add any UI in the constructor.

               But it's also possible that AutoTamper* methods are called before OnLoad (below), so be
               sure any needed data structures are initialized to safe values here in this constructor */

            sUserAgent = "Violin";
            oView = new ViewPanel(); //UserControl1 is a Windows Forms UserControl class
        }

        //Required Function
        public void OnLoad()
        {

            //oPage.ImageIndex = (int)SessionIcons.Timeline;  //This sets the Icon image used in the tab

            
            oView.Dock = DockStyle.Fill;
            TabPage oPage = new TabPage("DCviewer");
            oPage.Controls.Add(oView);

            FiddlerApplication.UI.tabsViews.TabPages.Add(oPage);

            
        }

        //Required Function
        public void OnBeforeUnload()
        {
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            string url = oSession.fullUrl;
            if (url.Contains("log.dc.cn"))
            {
                oSession.oRequest["User-Agent"] = sUserAgent;
            }
        }

        public void AutoTamperRequestAfter(Session oSession)
        {
            //防止刚打开fiddler时，有数据进来但窗口还没初始化完成
            while (!oView.IsHandleCreated)
            {
                ;
            }

            oView.Invoke(new EventHandler(delegate
            {
                JArray jsons = new JArray();
                oView.url = oSession.fullUrl;
                oView.rawBody = "";
                string body = "";
                if (oView.url.Contains("log.dc.cn"))
                {
                    oView.rawBody = oSession.GetRequestBodyAsString();
                    //oView.rawBody = "eJztl01z2yAQhn8NvTmD0CeHHmRbufXj1iODANnUklAApU1%2BfVGiIFvjtpNk4kw7ungw%2B7K7sPuggZTUsj25pXUvPoJ4DdI1QIhQRuxdJ9wQhLn77Y3QlFmpWlKrnWwHA9oMSsP2oqGE3Qrt1QG%2BCpNJ0rfyhhzEnbfTVja0JrTlWknOxS3ptOJHC1w0IrnXxwlKoTdTSaqa7rx1sjBqxU7pKdBprqyWorXEymbaGIIBhlkQogDhaMqZMyOMGbZ7lEaQJgjyBK%2FCuOSrKMTBqhQwWqEqQzBJokDg0nsQP%2B1wYg3t%2FPrhbOPB1shWaeJObIjwODUoHgZJFXFYlQGOMUsESjniSVwGKA05pFEaj3IX42Fw3gmcqYjRbCZhdpxItz7nHW3Ek0O%2F6as0uEJx6EWukD%2BU5qR20vpMEWraTrW535PNZ29qhXVLD8RYVyivOXyTlZxrTroPeaurJz8Ts6uprZRuvKmRHZ0ayoibkzpO%2Flwm%2Bow%2F05fkfDMR10Ts4Phgqm%2BtXzD0FLlX7ZRz5m09P4od4izAJcQclhxlKZ5UlhEuq%2Bo0m6E4m4XJCzCpyu%2FCM%2FEESTTjaAH3fcGdNvN8cEdkPUMLt2%2FKbXohbhck3xfJ6BVILt%2FSyzI5neM%2Fw6RRvWbiL5%2FlBdwXgBu%2FAlzXn2bf7R2jRIubXpiF3v%2BHXmmutWq%2BdKL9Sndz9KzuxYyrxuxmotFVPAq0sBvFxfHUKH36C90%2BT8xoM3Pw6THIb9aDIgbZBmQxKFKQb8G6GGYwBNkWFAnIIcgDUGCQ54OsiMA6ezBhkEGAc1BkYH0NsvQPOXBq6SyDtq%2FroS9fchlpYfp6%2FtwI3u65IbRWmo1VOA45nvxzr9zlMj1hb7pPXnmZmk615iLvk3j74RfZfUiU";
                    //oView.rawBody = "eJyNlE1z2yAQhn8NvTkD6ANx6MFfPaY9dKZHBgGyGUugAEqb%2FPoixwZbk3p68azZZ99dVsuylgdxZK%2B8n9RXUG0A2QCMGRcsvI0qmqBYx9%2FJK8dF0Naw3h60mR14O5NeHNXAmXhVLtGIPhVVRiajX9hJvSU%2FN3rgPeNGOqulMGJgo7PyJiKmY1qmAIwpaeqGFiQxXLOu54eMJI%2FgQR2sy%2BnuKxa9ViawoId8PQwRhQQRRDEpcw4pvPJ%2BvvRNLbAUsKpFu6IlgqsS1nLVKk5XUjVdrLMoSVUmBfUnzH0b%2BJji5w5Xs0%2F7b84O30dlfvCD%2BjibkbMR3HQ9ikJnY%2FCHBXS%2B2HoKR4AbgOlFubrwTvmpD1sr1e3pJfj6F0MIMbkD8Pb2L4%2FyP%2BdR%2BLcG%2FI%2FwnfIPFMC%2BAk0FNjXYl2CzAbR%2BIPlxrygoHirWgBKwhmcjSp%2BNZgfWe7AnYLMDFJ2NmOxOHZDdou9xsucZWPQeLqiPqhYQWn5Cbaxjnwu2hZCiKbFABJe8JkgoxbEsUIfi3DfLfMo568Tl496mhLBYoN5OTiw5p3j%2FzIflkDHvxIIUIXfmOteHGHm9Rnr1TwQlID7339ZJ1kesz0jy99zkt%2Ft%2BZNvn5DIqxNAT8yE%2B5MScfulOL5m7HZU3QHwWD3fH2PPQWTckZsjKXr3cbZ5ccqwnrziYj6eWfb5y5gXlj%2BPRGsXieIzWeJXC5v3D3qMrxTTJN8mbCgraINpCKmErcUNopoJgUnfdfXfn8d19%2BQsLRoCU";
                    //oView.rawBody = "_batch_value=%5B%7B%22gameversion%22%3A%221.71%22%2C%22clienttype%22%3A%22Redmi+K20%22%2C%22clientversion%22%3A%229%22%2C%22sub_category%22%3A%22noti_recieve%22%2C%22src%22%3A%22gsp_client%22%2C%22equipment%22%3A%22nocrack%22%2C%22networktype%22%3A%22PSDN%22%2C%22type%22%3A%22notification%22%2C%22time_zone%22%3A%22%2B8%22%2C%22textId%22%3A%220%22%2C%22_ac_type%22%3A%2288%22%2C%22pf%22%3A%22he%22%2C%22viral_id%22%3A%2233-1565179044032-21119%22%2C%22location%22%3A%22CN%22%2C%22time%22%3A%2220190808155244%22%2C%22category%22%3A%22noti%22%2C%22lang%22%3A%22zh_CN%22%7D%2C%7B%22gameversion%22%3A%221.71%22%2C%22clienttype%22%3A%22Redmi+K20%22%2C%22clientversion%22%3A%229%22%2C%22sub_category%22%3A%22noti_recieve%22%2C%22src%22%3A%22gsp_client%22%2C%22equipment%22%3A%22nocrack%22%2C%22networktype%22%3A%22PSDN%22%2C%22type%22%3A%22notification%22%2C%22time_zone%22%3A%22%2B8%22%2C%22textId%22%3A%220%22%2C%22_ac_type%22%3A%2288%22%2C%22pf%22%3A%22he%22%2C%22viral_id%22%3A%2233-1565241110562-21125%22%2C%22location%22%3A%22CN%22%2C%22time%22%3A%2220190808155244%22%2C%22category%22%3A%22noti%22%2C%22lang%22%3A%22zh_CN%22%7D%5D&_user_id=33&_uniq_key=animal_androidcncm_prod";

                    try
                    {
                        body = HttpUtility.UrlDecode(oView.rawBody);                        
                        body = Lis2013HISWSTest.ZipHelper.GZipDecompressString(body);
                        body = body.Trim();
                    }
                    catch
                    {
                        //这里什么都不错，无法解压base64可能是因为本来就是解压过的

                        //showErrorForm.setErrorTextToRich("body解码 报错：\n" + oView.url + "\n" + body + "\n原始数据：\n" + oView.rawBody);
                        //showErrorForm.Show();
                        //showErrorForm.TopMost = true;
                    }

                    if (body.Length > 10)
                    {
                        try
                        {
                            body = HttpUtility.UrlDecode(body);
                            {
                                //抓幽灵bug
                                if (body.Length < 14)
                                {
                                    showErrorForm.setErrorTextToRich("body.Length < 14 报错：\n" + body + "\n原始数据：\n" + oView.rawBody);
                                    showErrorForm.Show();
                                    showErrorForm.TopMost = true;
                                }
                            }

                            //对URL中带字段值的打点进行特殊处理
                            if (body.EndsWith("&") == false)
                            {
                                int ind = body.LastIndexOf("]");
                                body = body.Substring(0, ind + 2);
                            }

                            body = body.Substring(13, body.Length - 14);
                            jsons = JArray.Parse(body);
                        }
                        catch
                        {
                            showErrorForm.setErrorTextToRich("body转JArray 报错：\n" + oView.url + "\n" + body + "\n原始数据：\n" + oView.rawBody);
                            showErrorForm.Show();
                            showErrorForm.TopMost = true;
                        }
                        
                        oView.addData(jsons);                                        
                    }
                }
            }));
        }

        //private string DirtDClog(string body)
        //{            
        //    string[] dirtList = body.Split('&');
        //    string clenBody = dirtList[0];
        //    return clenBody + "&";

        //    for (int i=1; i < dirtList.Length; i++)
        //    {
        //        string dirt = "\"" + dirtList[i].Replace("=", "\":\"") + "\",";
        //        clenBody = clenBody.Insert(15, dirt);
        //    }
                
        //    return clenBody + "&";
        //}
        
        public void AutoTamperResponseBefore(Session oSession) { }
        public void AutoTamperResponseAfter(Session oSession) { }
        public void OnBeforeReturningError(Session oSession) { }
    }


}
