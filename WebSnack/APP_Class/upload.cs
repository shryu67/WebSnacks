﻿using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;

namespace upload
{
    public class ezFileUpload : IDisposable
    {
        //相對路徑
        public string UploadPath { get; set; }

        //上層路徑
        public string UploadUpperPath { get { return UploadPath.Replace("~", ".."); } }

        //絕對路徑
        public string UploadRealPath { get { return HttpContext.Current.Server.MapPath(UploadPath); } }






        #region 解構子
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        /// <summary>
        /// 解構子,實現IDisposable中的Dispose方法
        /// </summary>
        public void Dispose()
        {
            //必須為true
            Dispose(true);
            //通知垃圾回收機制不再調用終端子（析構器）
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Car解構子
        /// </summary>
        /// <param name="disposing">disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            //解構時要執行的其它程式
            if (disposing)
            {
                handle.Dispose();
            }
            //讓類別知道自己已經被釋放
            disposed = true;
        }
        /// <summary>
        /// Car 解構子
        /// </summary>
        ~ezFileUpload()
        {
            //必須為false
            Dispose(false);
        }

        #endregion 解構子




        /// <summary>
        /// 建構子
        /// </summary>
        public ezFileUpload()
        {

            UploadPath = "~/img/goods";//避免空值

        }

        public ezFileUpload(string sUploadPath)
        {

            UploadPath = sUploadPath;//避免空值

        }


        public bool SaveUploadFile(HttpPostedFileBase photo)
        {
            bool bln_result = false;
            //上傳圖檔
            string fileName = "";
            //檔案上傳
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    //取得圖檔名稱
                    fileName = Path.GetFileName(photo.FileName);
                    var path = Path.Combine(UploadRealPath, fileName);
                    photo.SaveAs(path);
                    bln_result = true;
                }
            }
            return bln_result;


        }

        public string GetShowPhotosHtml(string sActionName)
        {
            string show = "";

            // 建立可操作Photos資料夾的dir物件
            DirectoryInfo dir = new DirectoryInfo(UploadRealPath);
            // 取得dir物件下的所有檔案(即Photos資料夾下)並放入finfo檔案資訊陣列
            FileInfo[] fInfo = dir.GetFiles();
            int n = 0;
            // 逐一將finfo檔案資訊陣列內的所有圖檔指定給show變數
            foreach (FileInfo result in fInfo)
            {
                n++;
                // 將目前取得的圖顯示在lblShow標籤內
                show += "<a href='" + UploadUpperPath + "/" + result.Name + "' target='_blank'><img src='" + UploadUpperPath + "/" + result.Name + "' width='90' height='60' border='0'></a>　";
                if (n % 4 == 0)    // 若顯示四個圖之後即跳一段落
                {
                    show += "<p>";
                }
            }
            // show變數再加上 '返回' Create動作方法的連結
            show += "<p><a href='" + sActionName + "'>返回</a></p>";
            return show;
        }
    }
}