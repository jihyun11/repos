using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notpad
{
    public partial class Form1 : Form
    {

        private Boolean txtNoteChange;      // 내용 변경 확인 
        private String fWord;               // 찾기 문자열 
        private Form2 frm2;                 // 찾기 폼 

        public Form1()
        {
            InitializeComponent();
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtNoteChange == true)
            {
                var msg = Text + " 파일 내용이 변경되었습니다.\r\n변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if(dlr == DialogResult.Yes)
                {
                    txtSave();
                    txtOpen();
                }
            }
            else
            {
                txtOpen();
            }
        }

        private void txtOpen()
        {
            var dlr = openFileDialog1.ShowDialog();
            if(dlr == DialogResult.OK)
            {
                var str = openFileDialog1.FileName;
                var sr = new StreamReader(str, System.Text.Encoding.Default);
                txtNote.Text = sr.ReadToEnd();
                sr.Close();

                var f = new FileInfo(str);
                Text = f.Name;
                txtNoteChange = false;
            }
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSave();
        }

        private void txtSave()
        {
            if(Text == "메모장")
            {
               DialogResult dlr = saveFileDialog1.ShowDialog();
                if(dlr != DialogResult.Cancel)
                {
                    String str = saveFileDialog1.FileName;

                    StreamWriter sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                    sw.Write(txtNote.Text);
                    sw.Flush();
                    sw.Close();

                    FileInfo fileInfo = new FileInfo(str);
                    Text = fileInfo.Name;
                    txtNoteChange = false;
                }
            } 
            else
            {
                String str = Text;
                StreamWriter sw = new StreamWriter(str, true, System.Text.Encoding.Default);

                sw.Write(txtNote.Text);
                sw.Flush();
                sw.Close();

                Text = str;
                txtNoteChange = false;
            }
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            txtNoteChange = true;
        }

        private void 새로만들기NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtNoteChange == true)
            {
                var msg = Text + " 파일 내용이 변경되었습니다.\r\n변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dlr == DialogResult.Yes)
                {
                    txtSave();
                    txtNote.ResetText();
                    Text = "메모장";
                    txtNoteChange = false;
                } 
                else if(dlr == DialogResult.No)
                {
                    txtNote.ResetText();
                    Text = "메모장";
                    txtNoteChange= false;
                }
                else if(dlr == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    return;
                }
            } 
            else
            {
                txtNote.ResetText();
                Text = "메모장";
                txtNoteChange = false;
            }
        }

        private void 다른이름으로저장AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlr = saveFileDialog1.ShowDialog();
            if(dlr == DialogResult.Yes)
            {
                var str = saveFileDialog1.FileName;
                var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                sw.Write(txtNote.Text);
                sw.Flush();
                sw.Close();

                var fileInfo = new FileInfo(str);
                this.Text = fileInfo.Name;
                txtNoteChange = false;
            }
        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Close();
        }

        private void 자동줄바꿈WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.WordWrap = !(txtNote.WordWrap);
            자동줄바꿈WToolStripMenuItem.Checked = !(자동줄바꿈WToolStripMenuItem.Checked);
        }

        private void 글꼴FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlr = fontDialog1.ShowDialog();
            if(dlr == DialogResult.OK)
            {
                txtNote.Font = fontDialog1.Font;
            }
        }

        private void 실행취소UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Undo();
        }

        private void 잘라내기TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Cut();
        }

        private void 복사CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Copy();
        }

        private void 붙여넣기PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Paste();
        }

        private void 삭제LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectedText = "";
        }

        private void 모두선택AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectAll();
        }

        private void 시간날짜DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToLongTimeString();
            var day = DateTime.Now.ToShortDateString();
            txtNote.AppendText("\n" + time + " : " + day);
        }

        private void 메모장정보AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void 찾기FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!(frm2 == null || !frm2.Visible))
            {
                frm2.Focus();
                return;
            } 

            frm2 = new Form2();

            if(txtNote.SelectionLength == 0)
            {
                MessageBox.Show("단어를 먼저 선택하세요.");
                return;
            } 
            else
            {
                frm2.txtWord.Text = txtNote.SelectedText;
            }

            frm2.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            frm2.Show();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var updown = -1;
            var str = txtNote.Text;
            var findWord = frm2.txtWord.Text;

            if (!frm2.chkCase.Checked)
            {
                str = str.ToUpper();
                findWord = findWord.ToUpper();
            }

            if (frm2.rdBtnUp.Checked)
            {
                if(txtNote.SelectionStart != 0)
                {
                    updown = str.LastIndexOf(findWord, txtNote.SelectionStart - 1);
                }
            }
            else
            {
                updown = str.IndexOf(findWord, txtNote.SelectionStart + txtNote.SelectionLength);
            }

            if(updown == -1)
            {
                MessageBox.Show("더 이상 찾는 문자열이 없습니다.", "찾기", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtNote.Select(updown, findWord.Length);
            fWord = frm2.txtWord.Text;
            txtNote.Focus();
            txtNote.ScrollToCaret();
        }
    }
}
