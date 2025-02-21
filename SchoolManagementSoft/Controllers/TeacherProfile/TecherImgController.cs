using SchoolManagementSoft.Models;
using SchoolManagementSoft.Models.DBMODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSoft.Controllers.TeacherProfile
{
    public class TecherImgController : Controller
    {
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private SchoolMDBEntities db = new SchoolMDBEntities();
        DateTime cdt = DateTime.Now.Date;
        // GET: TecherImg
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Thumbnail(string id, int width, int height)
        {


            var photo = await db.TeacherPictures.Where(s => s.TeacherID.Equals(id)).Select(x => x.Picture).FirstOrDefaultAsync();
            if (photo == null)
            {
                //string filePath = Server.MapPath(Url.Content("~/Content/img/no.jpg"));

                var dir = Server.MapPath("/Content/img/no-photo.png");
                var path = Path.Combine(dir); //validate the path for security or use other means to generate the path.
                return base.File(path, "image/jpeg");


            }
            var base64 = Convert.ToBase64String(photo);
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            using (var newImage = new Bitmap(width, height))
            using (var graphics = Graphics.FromImage(newImage))
            using (var stream = new MemoryStream())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(0, 0, width, height));
                newImage.Save(stream, ImageFormat.Png);

                return File(stream.ToArray(), "image/png");

            }

        }
    }
}