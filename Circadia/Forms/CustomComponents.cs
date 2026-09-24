using System.Drawing.Drawing2D;
using Circadia.Forms.Fonts;

namespace Circadia.Custom;

public static class CustomComponents
{
    public static TrackBar CreateTrackBar()
    {
        return new TrackBar()
        {
            Height = 35,
            BackColor = Color.FromArgb(20, 22, 30),
            TickStyle = TickStyle.None,
            LargeChange = 10,
            SmallChange = 1,
            TabStop = false
        };
    }


    public static Label CreateValueLabel(string text, Color color)
    {
        return new Label()
        {
            Text = text,
            Font = CustomFontCollection.GetMontserrat(
                8.5f,
                FontStyle.Bold
            ),
            ForeColor = color,
            BackColor = Color.FromArgb(32, 35, 47),
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(48, 26)
        };
    }


    public static DateTimePicker CreateTimePicker()
    {
        DateTimePicker picker = new DateTimePicker()
        {
            Width = 140,
            Height = 34,
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "HH:mm",
            ShowUpDown = true,
            Font = CustomFontCollection.GetMontserrat(
                9,
                FontStyle.Bold
            ),
            CalendarForeColor = Color.White,
            CalendarMonthBackground = Color.FromArgb(20, 22, 30)
        };

        return picker;
    }


    public static Button CreateModernButton(
        string text,
        Color background,
        Color foreground)
    {
        Button button = new Button()
        {
            Text = text,
            BackColor = background,
            ForeColor = foreground,
            FlatStyle = FlatStyle.Flat,
            Font = CustomFontCollection.GetMontserrat(
                9,
                FontStyle.Bold
            ),
            Cursor = Cursors.Hand,
            TabStop = false,
            UseVisualStyleBackColor = false
        };

        button.FlatAppearance.BorderSize = 0;

        ApplyRoundedCorners(button, 12);

        Color normalColor = background;

        button.MouseEnter += (s, e) =>
        {
            button.BackColor = Color.FromArgb(
                Math.Min(normalColor.R + 12, 255),
                Math.Min(normalColor.G + 12, 255),
                Math.Min(normalColor.B + 12, 255)
            );
        };

        button.MouseLeave += (s, e) =>
        {
            button.BackColor = normalColor;
        };

        return button;
    }


    public static Panel CreateCard(
        Point location,
        Size size,
        Color background,
        Color borderColor)
    {
        Panel panel = new Panel()
        {
            Location = location,
            Size = size,
            BackColor = background
        };

        panel.Paint += (sender, e) =>
        {
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                0,
                0,
                panel.Width - 1,
                panel.Height - 1
            );

            using GraphicsPath path =
                RoundedRect(rect, 16);

            using Pen pen =
                new Pen(borderColor, 1);

            e.Graphics.DrawPath(pen, path);
        };

        return panel;
    }


    public static void ApplyRoundedCorners(Control control, int radius)
    {
        void UpdateRegion()
        {
            if (control.Width <= 0 || control.Height <= 0)
                return;

            Rectangle rect = new Rectangle(
                0,
                0,
                control.Width,
                control.Height
            );

            using GraphicsPath path =
                RoundedRect(rect, radius);

            control.Region =
                new Region(path);
        }

        control.Resize += (s, e) =>
        {
            UpdateRegion();
        };

        UpdateRegion();
    }


    public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;

        GraphicsPath path = new GraphicsPath();

        Rectangle arc = new Rectangle(
            bounds.X,
            bounds.Y,
            diameter,
            diameter
        );

        path.AddArc(arc, 180, 90);

        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);

        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        arc.X = bounds.X;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();

        return path;
    }
}