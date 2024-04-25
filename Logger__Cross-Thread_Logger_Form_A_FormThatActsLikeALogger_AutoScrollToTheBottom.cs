/*

== Logger Form ==

// require
private System.Windows.Forms.TextBox textBox1; // on the form



*/


 public FormLogger()
 {
     InitializeComponent();

     textBox1.Dock = DockStyle.Fill; // Scale label1 to occupy the full form
     //textBox1.AutoSize = false; // Allow label1 to occupy multiple lines
     textBox1.Multiline = true; // Enable multiline mode
     textBox1.ScrollBars = ScrollBars.Vertical; // Enable vertical scrollbars
     textBox1.BorderStyle = BorderStyle.None; // Set border style to None for a flat appearance
     textBox1.ReadOnly = true; // Set the TextBox to read-only to resemble a Label
     textBox1.BackColor = SystemColors.Control; // Set the background color to match the form's background


 }

 long logLen=0;
 public void log(string message)
 {
     Action updateLabelAction = () => {

         //textBox1.Text += message + Environment.NewLine;
         textBox1.AppendText(" " + message + Environment.NewLine);
         // Calculate the offset needed to scroll to the bottom
        // int bottomOffset = textBox1.ClientSize.Height - textBox1.GetPositionFromCharIndex(textBox1.TextLength).Y;

        // textBox1.Text += "     buttom offset : " + bottomOffset.ToString() + "" + Environment.NewLine;

         // Set the AutoScrollOffset to scroll to the calculated bottom offset
         //textBox1.AutoScrollOffset = new Point(0, bottomOffset);

         // Set the SelectionStart to the end of the text
         textBox1.SelectionStart = textBox1.Text.Length;

         // Set the SelectionLength to 0 (to ensure the caret is at the end without any selection)
         textBox1.SelectionLength = 0;

         // Scroll to the caret position (end of the text) to force immediate scrolling
         textBox1.ScrollToCaret();
     };

     if (textBox1.InvokeRequired)
     {
         textBox1.BeginInvoke(updateLabelAction);
     }
     else
     {
         updateLabelAction.Invoke();
     }
 }
