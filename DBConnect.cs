using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Data;

namespace FormularioGrafica {

    internal class DBConnect {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect() {
            Initialize();
        }

        //Initialize values
        private void Initialize() {
            server = "localhost";
            database = "grafica";
            uid = "root";
            password = "admin";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection() {
            try {
                connection.Open();
                return true;
            }
            catch (MySqlException ex) {
                //When handling errors, you can your application's response based
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number) {
                    case 0:
                        MessageBox.Show("Não foi possível conectar com o banco.  Contate o administrator");
                        break;

                    case 1045:
                        MessageBox.Show("usuário ou senha incorretos, por favor tente novamente");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection() {
            try {
                connection.Close();
                return true;
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string nome, string preco, string tamanhoX, string tamanhoY) {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";
            string query = "INSERT INTO servicos (Nome, Preco, TamanhoX, TamanhoY) " +
                    "VALUES('" + nome + "','" + preco + "', '" + tamanhoX + "', '" + tamanhoY + "')";

            //open connection
            if (this.OpenConnection() == true) {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try {
                    //Execute command
                    cmd.ExecuteNonQuery();// Caso ocorra uma exception a execução pula a linha abaixo
                    MessageBox.Show("Serviço registrado com sucesso!");
                }
                catch (MySqlException ex) when (ex.Number == 1062) {//Duplicate key
                    MessageBox.Show("O nome deste serviço já existe! Por favor, registre um nome diferente.");
                }
                catch (MySqlException ex) when (ex.Number == 1406) {//Nome muito longo
                    MessageBox.Show("O nome deste serviço ultrapassou o limite de 30 caracteres! Por favor, registre um nome menor.");
                }
                catch (MySqlException ex) when (ex.Number == 1265) {//Caracter em campo float
                    MessageBox.Show("Os campos Preço e Tamanho aceitam somente números! Por favor, modifique o(s) campo(s) incorreto(s).");
                }
                catch (MySqlException ex) when (ex.Number == 1264) {//Ultrapassar 32 bits do float
                    MessageBox.Show("Os campos Preço ou Tamanho ultrapassaram o limite de memória! Por favor, registre um valor menor.");
                }
                //close connection
                this.CloseConnection();
            }

        }

        //Update statement
        public void Update(List<string> dadosAtuais, List<string> dadosNovos) {
            //string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            if (dadosNovos[0] == "")
                dadosNovos[0] = dadosAtuais[0];

            if (dadosNovos[1] == "")
                dadosNovos[1] = dadosAtuais[1];

            if (dadosNovos[2] == "")
                dadosNovos[2] = dadosAtuais[2];

            if (dadosNovos[3] == "")
                dadosNovos[3] = dadosAtuais[3];

            string query = "UPDATE servicos SET " +
                "Nome='" + dadosNovos[0] + "', " +
                "Preco='" + dadosNovos[1] + "', " +
                "TamanhoX='" + dadosNovos[2] + "'," +
                "TamanhoY= '" + dadosNovos[3] + "' " +
                "WHERE (Nome='" + dadosAtuais[0] + "')" +
                "AND(Preco= '" + dadosAtuais[1] + "')" +
                "AND(TamanhoX='" + dadosAtuais[2] + "')" +
                "AND(TamanhoY= '" + dadosAtuais[3] + "')";
            //Open connection
            if (this.OpenConnection() == true) {
                //create mysql command
                //MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                // cmd.ExecuteNonQuery();

                try {
                    cmd.ExecuteNonQuery();// Caso ocorra uma exception a execução pula a linha abaixo
                    if (cmd.Parameters.Count == 0) // Mudar o if para pegar quando o comando executa
                        MessageBox.Show("Não foi possível atualizar! Será que o nome deste serviço já existe?");
                    else
                        MessageBox.Show("Serviço atualizado com sucesso!");
                }
                catch (MySqlException ex) when (ex.Number == 1292) {//Caracter em campo float
                    MessageBox.Show("Os campos Preço e Tamanho aceitam somente números! Por favor, modifique o(s) campo(s) incorreto(s).");
                }
                catch (MySqlException ex) when (ex.Number == 1264) {//Ultrapassar 32 bits do float
                    MessageBox.Show("Os campos Preço ou Tamanho ultrapassaram o limite de memória! Por favor, registre um valor menor.");
                }
                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string nome, string preco, string tamanhoX, string tamanhoY) {
            //string query = "DELETE FROM tableinfo WHERE name='John Smith'";
            string query = "DELETE FROM servicos " +
                "WHERE (Nome='" + nome + "')AND(Preco= '" + preco + "')AND(TamanhoX='" + tamanhoX + "')AND(TamanhoY= '" + tamanhoY + "')";
            if (this.OpenConnection() == true) {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try {
                    //Execute command
                    cmd.ExecuteNonQuery();// Caso ocorra uma exception a execução pula a linha abaixo
                    if (cmd.Parameters.Count == 0)
                        MessageBox.Show("Serviço não encontrado!");
                    else
                        MessageBox.Show("Serviço removido com sucesso!");
                }
                catch (MySqlException ex) when (ex.Number == 1292) {//Caracter em campo float
                    MessageBox.Show("Os campos Preço e Tamanho aceitam somente números! Por favor, modifique o(s) campo(s) incorreto(s).");
                }
                catch (MySqlException ex) when (ex.Number == 1264) {//Ultrapassar 32 bits do float
                    MessageBox.Show("Os campos Preço ou Tamanho ultrapassaram o limite de memória! Por favor, registre um valor menor.");
                }
                //close connection
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select(string querySelect) {
            // string query = "SELECT * FROM funcionarios";
            string query = querySelect;

            //Create a list to store the result
            List<string>[] list = new List<string>[2];
            list[0] = new List<string>();
            list[1] = new List<string>();
            // list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true) {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read()) {
                    //list[0].Add(dataReader["CPF"] + "");
                    list[0].Add(dataReader["nome"] + "");
                    list[1].Add(dataReader["senha"] + "");

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else {
                return list;
            }

        }

        public DataTable Select(string nome, string preco, string tamanhoX, string tamanhoY) {
            DataTable tabela = new DataTable();
            string query = "SELECT nome,preco,tamanhoX,tamanhoY FROM servicos " +
                "WHERE (Nome LIKE '" + nome + "%')AND(Preco LIKE '" + preco + "%')" +
                "AND(TamanhoX LIKE'" + tamanhoX + "%')AND(TamanhoY LIKE '" + tamanhoY + "%')";

            if (this.OpenConnection() == true) {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try {
                    MySqlDataAdapter mySQLadaptador = new MySqlDataAdapter(query, connection);
                    mySQLadaptador.Fill(tabela);

                }
                catch (MySqlException ex) when (ex.Number == 1406) {//Nome muito longo
                    MessageBox.Show("O nome deste serviço ultrapassou o limite de 30 caracteres! Por favor, registre um nome menor.");
                }
                catch (MySqlException ex) when (ex.Number == 1292) {//Caracter em campo float
                    MessageBox.Show("Os campos Preço e Tamanho aceitam somente números! Por favor, modifique o(s) campo(s) incorreto(s).");
                }
                catch (MySqlException ex) when (ex.Number == 1264) {//Ultrapassar 32 bits do float
                    MessageBox.Show("Os campos Preço ou Tamanho ultrapassaram o limite de memória! Por favor, registre um valor menor.");
                }
                //close connection
                this.CloseConnection();

            }
            return tabela;

        }

        //Count statement
        //Retornar só um valor
        public int Count() {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true) {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else {
                return Count;
            }
        }

        //Backup
        public void Backup() {
            try {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex) {
                MessageBox.Show("Erro, não é possivel fazer backup!");
            }
        }

        //Restore
        //Restore
        public void Restore() {
            try {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex) {
                MessageBox.Show("Error, não é possível restaurar!");
            }
        }
    }
}

// site para conectar https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL