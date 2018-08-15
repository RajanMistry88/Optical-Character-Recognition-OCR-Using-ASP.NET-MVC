using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODI;
using System.Web.Mvc;
using System.IO;
using OCR.Models;

namespace OCR.Controllers
{
    public class OCRController : Controller
    {
        // GET: OCR
        public ActionResult Index()
        {
            return View();
               }

        [HttpPost]
        public ActionResult Index(OCRModelClass modelOCR, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = getUniqueFileName(Path.GetFileName(file.FileName));
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                    string extractText = this.ExtractTextFromImage(_path, modelOCR.language);
                    ViewBag.ImageText = extractText;
                }
                ViewBag.Message = "File Uploaded Successfully.";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
        // Document is Extract the text from Image.
        private string ExtractTextFromImage(string filePath, string language)
        {

            Document modiDocument = new Document();
            modiDocument.Create(filePath);
            modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);
            MODI.Image modiImage = (modiDocument.Images[0] as MODI.Image);
            string extractedText = modiImage.Layout.Text;
            modiDocument.Close();
            return extractedText;
        }
        // Guid is Globally Unique Identifier (GUID) is a 128-bit integer that you can use across all computers and networks wherever a unique identifier is required. 
        public static string getUniqueFileName(string fileName)
        {
            Guid guid = Guid.NewGuid();
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var fileExtension = Path.GetExtension(fileName);
            var uniqueFileName = fileNameWithoutExtension + "" + guid + "" + fileExtension;
            return uniqueFileName;
        }


        public void TestOtherLanguage()
        {
            //Document modiDocument = new Document();
            //modiDocument.Create(filePath);
            //switch (language)
            //{
            //    case "CHINESE_SIMPLIFIED":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_CHINESE_SIMPLIFIED);
            //        break;

            //    case "CHINESE_TRADITIONAL":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_CHINESE_TRADITIONAL);
            //        break;

            //    case "CZECH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_CZECH);
            //        break;

            //    case "DANISH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_DANISH);
            //        break;

            //    case "DUTCH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_DUTCH);
            //        break;

            //    case "ENGLISH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);
            //        break;

            //    case "FINNISH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_FINNISH);
            //        break;

            //    case "FRENCH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_FRENCH);
            //        break;

            //    case "GERMAN":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_GERMAN);
            //        break;

            //    case "GREEK":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_GREEK);
            //        break;

            //    case "HUNGARIAN":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_HUNGARIAN);
            //        break;

            //    case "ITALIAN":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_ITALIAN);
            //        break;

            //    case "JAPANESE":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_JAPANESE);
            //        break;

            //    case "KOREAN":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_KOREAN);
            //        break;

            //    case "NORWEGIAN":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_NORWEGIAN);
            //        break;

            //    case "POLISH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_POLISH);
            //        break;

            //    case "PORTUGUESE":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_PORTUGUESE);
            //        break;

            //    case "RUSSIAN":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_RUSSIAN);
            //        break;

            //    case "SPANISH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_SPANISH);
            //        break;

            //    case "SWEDISH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_POLISH);
            //        break;

            //    case "SYSDEFAULT":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_SYSDEFAULT);
            //        break;

            //    case "TURKISH":
            //        modiDocument.OCR(MiLANGUAGES.miLANG_TURKISH);
            //        break;

            //    default:
            //        modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);
            //        break;

            //}


            //modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);
            //MODI.Image modiImage = (modiDocument.Images[0] as MODI.Image);
            //string extractedText = modiImage.Layout.Text;
            //modiDocument.Close();
            //return extractedText;

        }


        //public void List()
        //{
        //    modelLanguage.languages.Add(new SelectListItem { Text = "CHINESE SIMPLIFIED", Value = "CHINESESIMPLIFIED" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "CHINESE TRADITIONAL", Value = "CHINESETRADITIONAL" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "CZECH", Value = "CZECH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "DANISH", Value = "DANISH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "DUTCH", Value = "DUTCH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "ENGLISH", Value = "ENGLISH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "FINNISH", Value = "FINNISH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "FRENCH", Value = "FRENCH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "GERMAN", Value = "GERMAN" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "GREEK", Value = "GREEK" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "HUNGARIAN", Value = "HUNGARIAN" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "ITALIAN", Value = "ITALIAN" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "JAPANESE", Value = "JAPANESE" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "KOREAN", Value = "KOREAN" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "NORWEGIAN", Value = "NORWEGIAN" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "POLISH", Value = "POLISH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "PORTUGUESE", Value = "PORTUGUESE" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "RUSSIAN", Value = "RUSSIAN" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "SPANISH", Value = "SPANISH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "SWEDISH", Value = "SWEDISH" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "SYSDEFAULT", Value = "SYSDEFAULT" });
        //    modelLanguage.languages.Add(new SelectListItem { Text = "TURKISH", Value = "TURKISH" });
        //}
    }
}