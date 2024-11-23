using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

public static class Theme
{
    private static readonly Dictionary<ToolStripItem, Image> originalImages = new Dictionary<ToolStripItem, Image>();
    private static readonly Dictionary<ToolStripItem, Image> invertedImages = new Dictionary<ToolStripItem, Image>();

    public static void ApplyTheme(Form form, bool isDarkTheme)
    {
        Color backgroundColor = isDarkTheme ? Color.FromArgb(28, 28, 28) : Color.White;
        Color textColor = isDarkTheme ? Color.White : Color.FromArgb(28, 28, 28);
        Color buttonColor = isDarkTheme ? Color.DarkGray : Color.LightGray;

        // Изменяем цвета для основного окна
        form.BackColor = backgroundColor;
        form.ForeColor = textColor;

        foreach (Control control in form.Controls)
        {
            if (control.Name != "playPauseButton")
            {
                ApplyThemeToControl(control, isDarkTheme, backgroundColor, textColor, buttonColor);
            }
        }
    }

    private static void ApplyThemeToControl(Control control, bool isDarkTheme, Color backgroundColor, Color textColor, Color buttonColor)
    {
        control.BackColor = backgroundColor;
        control.ForeColor = textColor;

        if (control.Name == "StopPlayButton")
        {
            control.BackColor = Color.LightGray;
            control.ForeColor = textColor;
            return;
        }

        if (control.Name == "PrevButton")
        {
            control.BackColor = Color.LightGray;
            control.ForeColor = textColor;
            return;
        }

        if (control.Name == "NextButton")
        {
            control.BackColor = Color.LightGray;
            control.ForeColor = textColor;
            return;
        }

        if (control is Button button)
        {
            button.FlatAppearance.BorderColor = buttonColor;
            button.FlatAppearance.MouseOverBackColor = buttonColor;
            button.FlatAppearance.MouseDownBackColor = buttonColor;
        }

        if (control is ToolStrip toolStrip)
        {
            toolStrip.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors(isDarkTheme));
            foreach (ToolStripItem item in toolStrip.Items)
            {
                ApplyThemeToToolStripItem(item, isDarkTheme);
            }
        }

        if (control is Panel panel)
        {
            foreach (Control panelControl in panel.Controls)
            {
                if (panelControl.Name != "playPauseButton")
                {
                    ApplyThemeToControl(panelControl, isDarkTheme, backgroundColor, textColor, buttonColor);
                }
            }
        }
    }

    private static void ApplyThemeToToolStripItem(ToolStripItem item, bool isDarkTheme)
    {
        if (item.Image != null)
        {
            if (isDarkTheme)
            {
                if (!invertedImages.ContainsKey(item))
                {
                    if (!originalImages.ContainsKey(item))
                    {
                        originalImages[item] = item.Image;
                    }
                    invertedImages[item] = InvertImage(originalImages[item]);
                }
                item.Image = invertedImages[item];
            }
            else
            {
                if (originalImages.ContainsKey(item))
                {
                    item.Image = originalImages[item];
                }
            }
        }

        if (item is ToolStripDropDownButton dropDownButton)
        {
            foreach (ToolStripItem dropDownItem in dropDownButton.DropDownItems)
            {
                ApplyThemeToToolStripItem(dropDownItem, isDarkTheme);
            }
        }
    }

    private static Image InvertImage(Image originalImage)
    {
        Bitmap invertedImage = new Bitmap(originalImage.Width, originalImage.Height);
        using (Graphics g = Graphics.FromImage(invertedImage))
        {
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            {
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}
            });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
        }
        return invertedImage;
    }

    private class CustomProfessionalColors : ProfessionalColorTable
    {
        private readonly bool isDarkTheme;

        public CustomProfessionalColors(bool isDarkTheme)
        {
            this.isDarkTheme = isDarkTheme;
        }

        public override Color ToolStripGradientBegin => isDarkTheme ? Color.DarkGray : Color.LightGray;
        public override Color ToolStripGradientMiddle => isDarkTheme ? Color.Gray : Color.WhiteSmoke;
        public override Color ToolStripGradientEnd => isDarkTheme ? Color.DarkGray : Color.LightGray;
        public override Color MenuStripGradientBegin => isDarkTheme ? Color.DarkGray : Color.LightGray;
        public override Color MenuStripGradientEnd => isDarkTheme ? Color.DarkGray : Color.LightGray;
    }
}