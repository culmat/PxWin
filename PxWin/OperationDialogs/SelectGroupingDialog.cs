﻿using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using PCAxis.Paxiom;

namespace PCAxis.Desktop.OperationDialogs
{
    public class GroupingSelectDialog : Form
    {
        private Variable _variable;
        private OperationsInfo _operationsInfo;

        private GroupingIncludesType _groupInclude;

        #region "Public properties"

        public Variable Variable
        {
            get { return _variable; }
            set
            {
                _variable = value;
                MyInit();
            }
        }

        public OperationsInfo OperationsInfo
        {
            get { return _operationsInfo; }
        }

        public GroupingIncludesType GroupInclude
        {
            get { return _groupInclude; }
        }

        #endregion

        #region "Button Eventhandlers"

        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {
            if ((this.lstGroupings.SelectedItem != null))
            {
                _operationsInfo = (OperationsInfo)this.lstGroupings.SelectedItem;

                if (lstGroupings.SelectedItem is GroupingInfo)
                {
                    if (this.rbAggregated.Checked)
                    {
                        _groupInclude = GroupingIncludesType.AggregatedValues;
                    }
                    else if (this.rbSingle.Checked)
                    {
                        _groupInclude = GroupingIncludesType.SingleValues;
                    }
                    else
                    {
                        _groupInclude = GroupingIncludesType.All;
                    }
                }
                else
                {
                    _groupInclude = GroupingIncludesType.AggregatedValues;
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        private void MyInit()
        {
            var list = new List<OperationsInfo>();

            if (_variable.HasGroupings())
            {
                list.AddRange(_variable.Groupings.Cast<OperationsInfo>());
            }

            if (_variable.HasValuesets())
            {
                list.AddRange(_variable.ValueSets.Cast<OperationsInfo>());
            }

            lstGroupings.DataSource = list;
            lstGroupings.DisplayMember = "Name";
        }

        private void lstGroupings_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((lstGroupings.SelectedItem != null))
            {
                if (lstGroupings.SelectedItem is GroupingInfo)
                {
                    pnlValues.Visible = true;
                }
                else
                {
                    pnlValues.Visible = false;
                }
            }
        }

        #region Autogenerated from design

        private ListBox lstGroupings;
        private Button btnOk;
        private Button btnCancel;
        private Panel pnlValues;
        private RadioButton rbBoth;
        private RadioButton rbSingle;
        private RadioButton rbAggregated;
        private Label lblValues;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupingSelectDialog));
            this.lstGroupings = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlValues = new System.Windows.Forms.Panel();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.rbAggregated = new System.Windows.Forms.RadioButton();
            this.lblValues = new System.Windows.Forms.Label();
            this.pnlValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstGroupings
            // 
            this.lstGroupings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGroupings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstGroupings.FormattingEnabled = true;
            this.lstGroupings.Location = new System.Drawing.Point(12, 12);
            this.lstGroupings.Name = "lstGroupings";
            this.lstGroupings.Size = new System.Drawing.Size(382, 353);
            this.lstGroupings.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(401, 13);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(114, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(401, 43);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // pnlValues
            // 
            this.pnlValues.Controls.Add(this.rbBoth);
            this.pnlValues.Controls.Add(this.rbSingle);
            this.pnlValues.Controls.Add(this.rbAggregated);
            this.pnlValues.Controls.Add(this.lblValues);
            this.pnlValues.Location = new System.Drawing.Point(401, 72);
            this.pnlValues.Name = "pnlValues";
            this.pnlValues.Size = new System.Drawing.Size(114, 98);
            this.pnlValues.TabIndex = 3;
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbBoth.Location = new System.Drawing.Point(6, 67);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(46, 17);
            this.rbBoth.TabIndex = 3;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbSingle.Location = new System.Drawing.Point(6, 43);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(53, 17);
            this.rbSingle.TabIndex = 2;
            this.rbSingle.Text = "Single";
            this.rbSingle.UseVisualStyleBackColor = true;
            // 
            // rbAggregated
            // 
            this.rbAggregated.AutoSize = true;
            this.rbAggregated.Checked = true;
            this.rbAggregated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAggregated.Location = new System.Drawing.Point(6, 20);
            this.rbAggregated.Name = "rbAggregated";
            this.rbAggregated.Size = new System.Drawing.Size(79, 17);
            this.rbAggregated.TabIndex = 1;
            this.rbAggregated.TabStop = true;
            this.rbAggregated.Text = "Aggregated";
            this.rbAggregated.UseVisualStyleBackColor = true;
            // 
            // lblValues
            // 
            this.lblValues.AutoSize = true;
            this.lblValues.Location = new System.Drawing.Point(3, 3);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(39, 13);
            this.lblValues.TabIndex = 0;
            this.lblValues.Text = "Values";
            // 
            // GroupingSelectDialog
            // 
            this.ClientSize = new System.Drawing.Size(522, 378);
            this.Controls.Add(this.pnlValues);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lstGroupings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupingSelectDialog";
            this.pnlValues.ResumeLayout(false);
            this.pnlValues.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}