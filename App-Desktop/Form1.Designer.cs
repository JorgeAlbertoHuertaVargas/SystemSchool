
namespace App_Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lista_Section = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.List_Section = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.imputdetail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imputname = new System.Windows.Forms.TextBox();
            this.Titulo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Lista_Section.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.List_Section)).BeginInit();
            this.Add.SuspendLayout();
            this.Titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lista_Section
            // 
            this.Lista_Section.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lista_Section.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Lista_Section.Controls.Add(this.label4);
            this.Lista_Section.Controls.Add(this.List_Section);
            this.Lista_Section.Location = new System.Drawing.Point(287, 95);
            this.Lista_Section.Name = "Lista_Section";
            this.Lista_Section.Size = new System.Drawing.Size(496, 329);
            this.Lista_Section.TabIndex = 6;
            this.Lista_Section.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(36, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "Listado de las Secciones";
            // 
            // List_Section
            // 
            this.List_Section.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List_Section.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.List_Section.Location = new System.Drawing.Point(69, 70);
            this.List_Section.Name = "List_Section";
            this.List_Section.RowTemplate.Height = 25;
            this.List_Section.Size = new System.Drawing.Size(380, 150);
            this.List_Section.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Add.Controls.Add(this.button2);
            this.Add.Controls.Add(this.button1);
            this.Add.Controls.Add(this.label5);
            this.Add.Controls.Add(this.imputdetail);
            this.Add.Controls.Add(this.label2);
            this.Add.Controls.Add(this.label1);
            this.Add.Controls.Add(this.imputname);
            this.Add.Location = new System.Drawing.Point(17, 95);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(253, 329);
            this.Add.TabIndex = 5;
            this.Add.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(124, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(39, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Información de la sección";
            // 
            // imputdetail
            // 
            this.imputdetail.Location = new System.Drawing.Point(13, 168);
            this.imputdetail.Multiline = true;
            this.imputdetail.Name = "imputdetail";
            this.imputdetail.Size = new System.Drawing.Size(219, 72);
            this.imputdetail.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Detalle de la Sección";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de la Sección";
            // 
            // imputname
            // 
            this.imputname.Location = new System.Drawing.Point(13, 94);
            this.imputname.Multiline = true;
            this.imputname.Name = "imputname";
            this.imputname.Size = new System.Drawing.Size(219, 23);
            this.imputname.TabIndex = 1;
            // 
            // Titulo
            // 
            this.Titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Titulo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Titulo.Controls.Add(this.label3);
            this.Titulo.Location = new System.Drawing.Point(17, 27);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(766, 51);
            this.Titulo.TabIndex = 4;
            this.Titulo.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(270, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "Modulo Sección";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lista_Section);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Titulo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Lista_Section.ResumeLayout(false);
            this.Lista_Section.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.List_Section)).EndInit();
            this.Add.ResumeLayout(false);
            this.Add.PerformLayout();
            this.Titulo.ResumeLayout(false);
            this.Titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Lista_Section;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView List_Section;
        private System.Windows.Forms.GroupBox Add;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox imputdetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imputname;
        private System.Windows.Forms.GroupBox Titulo;
        private System.Windows.Forms.Label label3;
    }
}

