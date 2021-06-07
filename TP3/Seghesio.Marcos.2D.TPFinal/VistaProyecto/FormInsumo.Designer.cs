﻿
namespace VistaProyecto
{
    partial class FormInsumo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlInsumos = new System.Windows.Forms.TabControl();
            this.tabPageListadoInsumos = new System.Windows.Forms.TabPage();
            this.tabPageAgregarInsumo = new System.Windows.Forms.TabPage();
            this.gbTela = new System.Windows.Forms.GroupBox();
            this.cmbColorTela = new System.Windows.Forms.ComboBox();
            this.lblColorTela = new System.Windows.Forms.Label();
            this.cmbTipoTela = new System.Windows.Forms.ComboBox();
            this.lblTipoTela = new System.Windows.Forms.Label();
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.dtpIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.rbInsumoAccesorio = new System.Windows.Forms.RadioButton();
            this.rbYute = new System.Windows.Forms.RadioButton();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.rbTela = new System.Windows.Forms.RadioButton();
            this.rbMadera = new System.Windows.Forms.RadioButton();
            this.btnAgregarInsumo = new System.Windows.Forms.Button();
            this.gbInsumosAccesorios = new System.Windows.Forms.GroupBox();
            this.rbTornillo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbPegamento = new System.Windows.Forms.RadioButton();
            this.rbBarniz = new System.Windows.Forms.RadioButton();
            this.gbMadera = new System.Windows.Forms.GroupBox();
            this.rbColumna = new System.Windows.Forms.RadioButton();
            this.rbTablon = new System.Windows.Forms.RadioButton();
            this.lblFormaMadera = new System.Windows.Forms.Label();
            this.cmbTipoMadera = new System.Windows.Forms.ComboBox();
            this.lblTipoMadera = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iBAgregarProducto = new FontAwesome.Sharp.IconButton();
            this.iBInsumos = new FontAwesome.Sharp.IconButton();
            this.dgStockInsumos = new System.Windows.Forms.DataGridView();
            this.lblStockInsumos = new System.Windows.Forms.Label();
            this.lblListaVacia = new System.Windows.Forms.Label();
            this.tabControlInsumos.SuspendLayout();
            this.tabPageListadoInsumos.SuspendLayout();
            this.tabPageAgregarInsumo.SuspendLayout();
            this.gbTela.SuspendLayout();
            this.gbProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.gbInsumosAccesorios.SuspendLayout();
            this.gbMadera.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockInsumos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlInsumos
            // 
            this.tabControlInsumos.Controls.Add(this.tabPageListadoInsumos);
            this.tabControlInsumos.Controls.Add(this.tabPageAgregarInsumo);
            this.tabControlInsumos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInsumos.Location = new System.Drawing.Point(0, 0);
            this.tabControlInsumos.Name = "tabControlInsumos";
            this.tabControlInsumos.SelectedIndex = 0;
            this.tabControlInsumos.Size = new System.Drawing.Size(1157, 667);
            this.tabControlInsumos.TabIndex = 14;
            // 
            // tabPageListadoInsumos
            // 
            this.tabPageListadoInsumos.Controls.Add(this.lblListaVacia);
            this.tabPageListadoInsumos.Controls.Add(this.lblStockInsumos);
            this.tabPageListadoInsumos.Controls.Add(this.dgStockInsumos);
            this.tabPageListadoInsumos.Location = new System.Drawing.Point(4, 22);
            this.tabPageListadoInsumos.Name = "tabPageListadoInsumos";
            this.tabPageListadoInsumos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListadoInsumos.Size = new System.Drawing.Size(1149, 641);
            this.tabPageListadoInsumos.TabIndex = 0;
            this.tabPageListadoInsumos.Text = "tabPage1";
            this.tabPageListadoInsumos.UseVisualStyleBackColor = true;
            // 
            // tabPageAgregarInsumo
            // 
            this.tabPageAgregarInsumo.Controls.Add(this.gbTela);
            this.tabPageAgregarInsumo.Controls.Add(this.gbProducto);
            this.tabPageAgregarInsumo.Controls.Add(this.btnAgregarInsumo);
            this.tabPageAgregarInsumo.Controls.Add(this.gbInsumosAccesorios);
            this.tabPageAgregarInsumo.Controls.Add(this.gbMadera);
            this.tabPageAgregarInsumo.Location = new System.Drawing.Point(4, 22);
            this.tabPageAgregarInsumo.Name = "tabPageAgregarInsumo";
            this.tabPageAgregarInsumo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAgregarInsumo.Size = new System.Drawing.Size(1149, 641);
            this.tabPageAgregarInsumo.TabIndex = 1;
            this.tabPageAgregarInsumo.Text = "tabPage2";
            this.tabPageAgregarInsumo.UseVisualStyleBackColor = true;
            // 
            // gbTela
            // 
            this.gbTela.Controls.Add(this.cmbColorTela);
            this.gbTela.Controls.Add(this.lblColorTela);
            this.gbTela.Controls.Add(this.cmbTipoTela);
            this.gbTela.Controls.Add(this.lblTipoTela);
            this.gbTela.Location = new System.Drawing.Point(747, 126);
            this.gbTela.Name = "gbTela";
            this.gbTela.Size = new System.Drawing.Size(233, 125);
            this.gbTela.TabIndex = 13;
            this.gbTela.TabStop = false;
            this.gbTela.Text = "Tela";
            // 
            // cmbColorTela
            // 
            this.cmbColorTela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorTela.FormattingEnabled = true;
            this.cmbColorTela.Location = new System.Drawing.Point(114, 62);
            this.cmbColorTela.Name = "cmbColorTela";
            this.cmbColorTela.Size = new System.Drawing.Size(93, 21);
            this.cmbColorTela.TabIndex = 14;
            // 
            // lblColorTela
            // 
            this.lblColorTela.AutoSize = true;
            this.lblColorTela.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblColorTela.Location = new System.Drawing.Point(19, 62);
            this.lblColorTela.Name = "lblColorTela";
            this.lblColorTela.Size = new System.Drawing.Size(58, 13);
            this.lblColorTela.TabIndex = 16;
            this.lblColorTela.Text = "Color Tela:";
            // 
            // cmbTipoTela
            // 
            this.cmbTipoTela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTela.FormattingEnabled = true;
            this.cmbTipoTela.Location = new System.Drawing.Point(114, 21);
            this.cmbTipoTela.Name = "cmbTipoTela";
            this.cmbTipoTela.Size = new System.Drawing.Size(93, 21);
            this.cmbTipoTela.TabIndex = 13;
            // 
            // lblTipoTela
            // 
            this.lblTipoTela.AutoSize = true;
            this.lblTipoTela.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblTipoTela.Location = new System.Drawing.Point(20, 28);
            this.lblTipoTela.Name = "lblTipoTela";
            this.lblTipoTela.Size = new System.Drawing.Size(31, 13);
            this.lblTipoTela.TabIndex = 15;
            this.lblTipoTela.Text = "Tipo:";
            // 
            // gbProducto
            // 
            this.gbProducto.Controls.Add(this.dtpIngreso);
            this.gbProducto.Controls.Add(this.lblFecha);
            this.gbProducto.Controls.Add(this.nudCantidad);
            this.gbProducto.Controls.Add(this.lblCantidad);
            this.gbProducto.Controls.Add(this.rbInsumoAccesorio);
            this.gbProducto.Controls.Add(this.rbYute);
            this.gbProducto.Controls.Add(this.lblTipoProducto);
            this.gbProducto.Controls.Add(this.rbTela);
            this.gbProducto.Controls.Add(this.rbMadera);
            this.gbProducto.Location = new System.Drawing.Point(49, 126);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(374, 125);
            this.gbProducto.TabIndex = 11;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Insumo";
            // 
            // dtpIngreso
            // 
            this.dtpIngreso.Location = new System.Drawing.Point(112, 89);
            this.dtpIngreso.Name = "dtpIngreso";
            this.dtpIngreso.Size = new System.Drawing.Size(243, 20);
            this.dtpIngreso.TabIndex = 17;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblFecha.Location = new System.Drawing.Point(7, 87);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.lblFecha.Size = new System.Drawing.Size(98, 23);
            this.lblFecha.TabIndex = 16;
            this.lblFecha.Text = "Fecha de Ingreso:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(80, 59);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(275, 20);
            this.nudCantidad.TabIndex = 16;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidadEstantes_ValueChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblCantidad.Location = new System.Drawing.Point(6, 53);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.lblCantidad.Size = new System.Drawing.Size(57, 23);
            this.lblCantidad.TabIndex = 15;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // rbInsumoAccesorio
            // 
            this.rbInsumoAccesorio.AutoSize = true;
            this.rbInsumoAccesorio.Location = new System.Drawing.Point(236, 21);
            this.rbInsumoAccesorio.Name = "rbInsumoAccesorio";
            this.rbInsumoAccesorio.Size = new System.Drawing.Size(119, 17);
            this.rbInsumoAccesorio.TabIndex = 14;
            this.rbInsumoAccesorio.TabStop = true;
            this.rbInsumoAccesorio.Text = "Insumos Accesorios";
            this.rbInsumoAccesorio.UseVisualStyleBackColor = true;
            this.rbInsumoAccesorio.CheckedChanged += new System.EventHandler(this.rbGeneric_CheckedChanged);
            // 
            // rbYute
            // 
            this.rbYute.AutoSize = true;
            this.rbYute.Location = new System.Drawing.Point(183, 22);
            this.rbYute.Name = "rbYute";
            this.rbYute.Size = new System.Drawing.Size(47, 17);
            this.rbYute.TabIndex = 13;
            this.rbYute.TabStop = true;
            this.rbYute.Text = "Yute";
            this.rbYute.UseVisualStyleBackColor = true;
            this.rbYute.CheckedChanged += new System.EventHandler(this.rbGeneric_CheckedChanged);
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(7, 23);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(31, 13);
            this.lblTipoProducto.TabIndex = 9;
            this.lblTipoProducto.Text = "Tipo:";
            // 
            // rbTela
            // 
            this.rbTela.AutoSize = true;
            this.rbTela.Location = new System.Drawing.Point(131, 22);
            this.rbTela.Name = "rbTela";
            this.rbTela.Size = new System.Drawing.Size(46, 17);
            this.rbTela.TabIndex = 8;
            this.rbTela.TabStop = true;
            this.rbTela.Text = "Tela";
            this.rbTela.UseVisualStyleBackColor = true;
            this.rbTela.CheckedChanged += new System.EventHandler(this.rbGeneric_CheckedChanged);
            // 
            // rbMadera
            // 
            this.rbMadera.AutoSize = true;
            this.rbMadera.Location = new System.Drawing.Point(64, 22);
            this.rbMadera.Name = "rbMadera";
            this.rbMadera.Size = new System.Drawing.Size(61, 17);
            this.rbMadera.TabIndex = 0;
            this.rbMadera.TabStop = true;
            this.rbMadera.Text = "Madera";
            this.rbMadera.UseVisualStyleBackColor = true;
            this.rbMadera.CheckedChanged += new System.EventHandler(this.rbGeneric_CheckedChanged);
            // 
            // btnAgregarInsumo
            // 
            this.btnAgregarInsumo.Location = new System.Drawing.Point(443, 274);
            this.btnAgregarInsumo.Name = "btnAgregarInsumo";
            this.btnAgregarInsumo.Size = new System.Drawing.Size(261, 37);
            this.btnAgregarInsumo.TabIndex = 12;
            this.btnAgregarInsumo.Text = "Agregar Insumo a Linea de Produccion";
            this.btnAgregarInsumo.UseVisualStyleBackColor = true;
            this.btnAgregarInsumo.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // gbInsumosAccesorios
            // 
            this.gbInsumosAccesorios.Controls.Add(this.rbTornillo);
            this.gbInsumosAccesorios.Controls.Add(this.label1);
            this.gbInsumosAccesorios.Controls.Add(this.rbPegamento);
            this.gbInsumosAccesorios.Controls.Add(this.rbBarniz);
            this.gbInsumosAccesorios.Enabled = false;
            this.gbInsumosAccesorios.Location = new System.Drawing.Point(49, 266);
            this.gbInsumosAccesorios.Name = "gbInsumosAccesorios";
            this.gbInsumosAccesorios.Size = new System.Drawing.Size(374, 78);
            this.gbInsumosAccesorios.TabIndex = 9;
            this.gbInsumosAccesorios.TabStop = false;
            this.gbInsumosAccesorios.Text = "Otros Insumos";
            // 
            // rbTornillo
            // 
            this.rbTornillo.AutoSize = true;
            this.rbTornillo.Location = new System.Drawing.Point(236, 32);
            this.rbTornillo.Name = "rbTornillo";
            this.rbTornillo.Size = new System.Drawing.Size(59, 17);
            this.rbTornillo.TabIndex = 17;
            this.rbTornillo.TabStop = true;
            this.rbTornillo.Text = "Tornillo";
            this.rbTornillo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tipo:";
            // 
            // rbPegamento
            // 
            this.rbPegamento.AutoSize = true;
            this.rbPegamento.Location = new System.Drawing.Point(131, 31);
            this.rbPegamento.Name = "rbPegamento";
            this.rbPegamento.Size = new System.Drawing.Size(79, 17);
            this.rbPegamento.TabIndex = 15;
            this.rbPegamento.TabStop = true;
            this.rbPegamento.Text = "Pegamento";
            this.rbPegamento.UseVisualStyleBackColor = true;
            // 
            // rbBarniz
            // 
            this.rbBarniz.AutoSize = true;
            this.rbBarniz.Location = new System.Drawing.Point(64, 31);
            this.rbBarniz.Name = "rbBarniz";
            this.rbBarniz.Size = new System.Drawing.Size(54, 17);
            this.rbBarniz.TabIndex = 14;
            this.rbBarniz.TabStop = true;
            this.rbBarniz.Text = "Barniz";
            this.rbBarniz.UseVisualStyleBackColor = true;
            // 
            // gbMadera
            // 
            this.gbMadera.Controls.Add(this.rbColumna);
            this.gbMadera.Controls.Add(this.rbTablon);
            this.gbMadera.Controls.Add(this.lblFormaMadera);
            this.gbMadera.Controls.Add(this.cmbTipoMadera);
            this.gbMadera.Controls.Add(this.lblTipoMadera);
            this.gbMadera.Location = new System.Drawing.Point(443, 126);
            this.gbMadera.Name = "gbMadera";
            this.gbMadera.Size = new System.Drawing.Size(261, 125);
            this.gbMadera.TabIndex = 10;
            this.gbMadera.TabStop = false;
            this.gbMadera.Text = "Madera";
            // 
            // rbColumna
            // 
            this.rbColumna.AutoSize = true;
            this.rbColumna.Location = new System.Drawing.Point(162, 59);
            this.rbColumna.Name = "rbColumna";
            this.rbColumna.Size = new System.Drawing.Size(66, 17);
            this.rbColumna.TabIndex = 14;
            this.rbColumna.TabStop = true;
            this.rbColumna.Text = "Columna";
            this.rbColumna.UseVisualStyleBackColor = true;
            // 
            // rbTablon
            // 
            this.rbTablon.AutoSize = true;
            this.rbTablon.Location = new System.Drawing.Point(94, 59);
            this.rbTablon.Name = "rbTablon";
            this.rbTablon.Size = new System.Drawing.Size(58, 17);
            this.rbTablon.TabIndex = 13;
            this.rbTablon.TabStop = true;
            this.rbTablon.Text = "Tablón";
            this.rbTablon.UseVisualStyleBackColor = true;
            // 
            // lblFormaMadera
            // 
            this.lblFormaMadera.AutoSize = true;
            this.lblFormaMadera.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblFormaMadera.Location = new System.Drawing.Point(6, 53);
            this.lblFormaMadera.Name = "lblFormaMadera";
            this.lblFormaMadera.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.lblFormaMadera.Size = new System.Drawing.Size(82, 23);
            this.lblFormaMadera.TabIndex = 10;
            this.lblFormaMadera.Text = "Forma madera:";
            // 
            // cmbTipoMadera
            // 
            this.cmbTipoMadera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMadera.Location = new System.Drawing.Point(55, 20);
            this.cmbTipoMadera.Name = "cmbTipoMadera";
            this.cmbTipoMadera.Size = new System.Drawing.Size(198, 21);
            this.cmbTipoMadera.TabIndex = 9;
            // 
            // lblTipoMadera
            // 
            this.lblTipoMadera.AutoSize = true;
            this.lblTipoMadera.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTipoMadera.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblTipoMadera.Location = new System.Drawing.Point(3, 16);
            this.lblTipoMadera.Name = "lblTipoMadera";
            this.lblTipoMadera.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.lblTipoMadera.Size = new System.Drawing.Size(36, 23);
            this.lblTipoMadera.TabIndex = 8;
            this.lblTipoMadera.Text = "Tipo:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.iBAgregarProducto);
            this.panel1.Controls.Add(this.iBInsumos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 78);
            this.panel1.TabIndex = 15;
            // 
            // iBAgregarProducto
            // 
            this.iBAgregarProducto.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iBAgregarProducto.Dock = System.Windows.Forms.DockStyle.Left;
            this.iBAgregarProducto.FlatAppearance.BorderSize = 0;
            this.iBAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBAgregarProducto.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBAgregarProducto.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iBAgregarProducto.IconColor = System.Drawing.Color.Snow;
            this.iBAgregarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBAgregarProducto.Location = new System.Drawing.Point(180, 0);
            this.iBAgregarProducto.Name = "iBAgregarProducto";
            this.iBAgregarProducto.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBAgregarProducto.Size = new System.Drawing.Size(180, 78);
            this.iBAgregarProducto.TabIndex = 3;
            this.iBAgregarProducto.Text = "Agregar Insumo";
            this.iBAgregarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBAgregarProducto.UseVisualStyleBackColor = false;
            this.iBAgregarProducto.Click += new System.EventHandler(this.iBAgregarInsumo_Click);
            // 
            // iBInsumos
            // 
            this.iBInsumos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iBInsumos.Dock = System.Windows.Forms.DockStyle.Left;
            this.iBInsumos.FlatAppearance.BorderSize = 0;
            this.iBInsumos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBInsumos.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBInsumos.IconChar = FontAwesome.Sharp.IconChar.List;
            this.iBInsumos.IconColor = System.Drawing.Color.Snow;
            this.iBInsumos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBInsumos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBInsumos.Location = new System.Drawing.Point(0, 0);
            this.iBInsumos.Name = "iBInsumos";
            this.iBInsumos.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBInsumos.Size = new System.Drawing.Size(180, 78);
            this.iBInsumos.TabIndex = 2;
            this.iBInsumos.Text = "Insumos";
            this.iBInsumos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBInsumos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBInsumos.UseVisualStyleBackColor = false;
            this.iBInsumos.Click += new System.EventHandler(this.iBInsumos_Click);
            // 
            // dgStockInsumos
            // 
            this.dgStockInsumos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgStockInsumos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgStockInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStockInsumos.Location = new System.Drawing.Point(55, 134);
            this.dgStockInsumos.Name = "dgStockInsumos";
            this.dgStockInsumos.ReadOnly = true;
            this.dgStockInsumos.Size = new System.Drawing.Size(1000, 308);
            this.dgStockInsumos.TabIndex = 0;
            // 
            // lblStockInsumos
            // 
            this.lblStockInsumos.AutoSize = true;
            this.lblStockInsumos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockInsumos.Location = new System.Drawing.Point(50, 90);
            this.lblStockInsumos.Name = "lblStockInsumos";
            this.lblStockInsumos.Size = new System.Drawing.Size(202, 29);
            this.lblStockInsumos.TabIndex = 1;
            this.lblStockInsumos.Text = "Insumos en Stock";
            // 
            // lblListaVacia
            // 
            this.lblListaVacia.AutoSize = true;
            this.lblListaVacia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaVacia.Location = new System.Drawing.Point(71, 164);
            this.lblListaVacia.Name = "lblListaVacia";
            this.lblListaVacia.Size = new System.Drawing.Size(334, 25);
            this.lblListaVacia.TabIndex = 2;
            this.lblListaVacia.Text = "Aun no se han agregado Insumos";
            // 
            // FormInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1157, 667);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlInsumos);
            this.Name = "FormInsumo";
            this.Text = "Fabrica";
            this.Load += new System.EventHandler(this.FormFabrica_Load);
            this.tabControlInsumos.ResumeLayout(false);
            this.tabPageListadoInsumos.ResumeLayout(false);
            this.tabPageListadoInsumos.PerformLayout();
            this.tabPageAgregarInsumo.ResumeLayout(false);
            this.gbTela.ResumeLayout(false);
            this.gbTela.PerformLayout();
            this.gbProducto.ResumeLayout(false);
            this.gbProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.gbInsumosAccesorios.ResumeLayout(false);
            this.gbInsumosAccesorios.PerformLayout();
            this.gbMadera.ResumeLayout(false);
            this.gbMadera.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStockInsumos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlInsumos;
        private System.Windows.Forms.TabPage tabPageListadoInsumos;
        private System.Windows.Forms.TabPage tabPageAgregarInsumo;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.Label lblTipoProducto;
        private System.Windows.Forms.RadioButton rbTela;
        private System.Windows.Forms.RadioButton rbMadera;
        private System.Windows.Forms.Button btnAgregarInsumo;
        private System.Windows.Forms.GroupBox gbInsumosAccesorios;
        private System.Windows.Forms.GroupBox gbMadera;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iBAgregarProducto;
        private FontAwesome.Sharp.IconButton iBInsumos;
        private System.Windows.Forms.RadioButton rbYute;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.RadioButton rbInsumoAccesorio;
        private System.Windows.Forms.Label lblFormaMadera;
        private System.Windows.Forms.ComboBox cmbTipoMadera;
        private System.Windows.Forms.Label lblTipoMadera;
        private System.Windows.Forms.GroupBox gbTela;
        private System.Windows.Forms.DateTimePicker dtpIngreso;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.RadioButton rbColumna;
        private System.Windows.Forms.RadioButton rbTablon;
        private System.Windows.Forms.ComboBox cmbColorTela;
        private System.Windows.Forms.Label lblColorTela;
        private System.Windows.Forms.ComboBox cmbTipoTela;
        private System.Windows.Forms.Label lblTipoTela;
        private System.Windows.Forms.RadioButton rbTornillo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbPegamento;
        private System.Windows.Forms.RadioButton rbBarniz;
        private System.Windows.Forms.Label lblStockInsumos;
        private System.Windows.Forms.DataGridView dgStockInsumos;
        private System.Windows.Forms.Label lblListaVacia;
    }
}