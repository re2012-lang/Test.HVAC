```csharp
using System;
using System.IO;
using DesignBuilder.API;

namespace SimpleReportPlugin
{
    public class SimpleReportPlugin : IPlugin
    {
        public void Execute(IDesignBuilderApplication app)
        {
            // دسترسی به مدل فعلی
            IModel model = app.ActiveModel;
            if (model == null)
            {
                app.ShowMessage("هیچ مدلی باز نیست.");
                return;
            }

            // شمارش تعداد بلوک‌ها
            int blockCount = model.Blocks.Count;

            // تولید گزارش ساده
            string report = $"تعداد بلوک‌های مدل: {blockCount}\nتاریخ: {DateTime.Now}";

            // ذخیره در فایل
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SimpleReport.txt");
            File.WriteAllText(filePath, report, System.Text.Encoding.UTF8);

            app.ShowMessage($"گزارش در {filePath} ذخیره شد.");
        }

        public string Name => "Simple Report Plugin";
        public string Description => "تولید گزارش ساده از مدل";
    }
}
