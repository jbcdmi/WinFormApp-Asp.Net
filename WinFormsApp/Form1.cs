using System.Data;
using System.Data.OleDb;
using System.Xml.Linq;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {

        OleDbConnection con;
        OleDbCommand cmd;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\bhautik jogani\WinFormsApp\MyDatabase.accdb;");
            LoadData();
        }

        // READ: Load data into DataGridView
        private void LoadData()
        {
            try
            {
                cmd = new OleDbCommand("SELECT * FROM users", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // CREATE: Add new user
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO users ([name], [email], [password], [active]) VALUES (?, ?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("?", txtName.Text);
                    cmd.Parameters.AddWithValue("?", txtEmail.Text);
                    cmd.Parameters.AddWithValue("?", txtPassword.Text);
                    cmd.Parameters.AddWithValue("?", chkActive.Checked);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("User added successfully!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        // UPDATE: Update selected user
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                string sql = "UPDATE users SET [name]=?, [email]=?, [password]=?, [active]=? WHERE [id]=?";

                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    // Add parameters in **exact order** of SQL placeholders
                    cmd.Parameters.AddWithValue("?", txtName.Text);
                    cmd.Parameters.AddWithValue("?", txtEmail.Text);
                    cmd.Parameters.AddWithValue("?", txtPassword.Text);
                    cmd.Parameters.AddWithValue("?", chkActive.Checked);
                    cmd.Parameters.AddWithValue("?", id); // WHERE id = ?

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("User updated successfully!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        // DELETE: Delete selected user
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                string sql = "DELETE FROM users WHERE id=?";
                cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User deleted successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
            }
        }

        // When user clicks a row, fill the text boxes for update
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["active"].Value);
            }
        }
    }
}