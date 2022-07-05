using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_memória_do_Dani
{


    public partial class Form1 : Form
    {

        // Use este objeto Random para escolher ícones aleatórios para os quadrados
        Random random = new Random();


        // Cada uma dessas letras é um ícone interessante
        // na fonte Webdings,
        // e cada ícone aparece duas vezes nesta lista
        List<string> icons = new List<string>()
    {
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
    };
        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
       

        private void AssignIconsToSquares()
        {
            // O TableLayoutPanel tem 16 rótulos,
            // e a lista de ícones tem 16 ícones,
            // então um ícone é puxado aleatoriamente da lista
            // e adicionado a cada rótulo
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labellll(object sender, EventArgs e)
        {
            
            
            Label clickedLabel = sender as Label;


            if (clickedLabel != null)
            {

                // Se o marcador clicado for preto, o player clicou
                // um ícone que já foi revelado --
                // ignora o clique
                if (clickedLabel.ForeColor == Color.Black)
                    return;


                // Se firstClicked for null, este é o primeiro ícone
                // no par que o jogador clicou,
                // então defina firstClicked para o rótulo que o jogador
                // clicado, muda sua cor para preto e retorna

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }
                
            }
            // O cronômetro é ativado apenas após dois não correspondentes
            // ícones foram mostrados ao jogador,
            // então ignore qualquer clique se o cronômetro estiver em execução
            if (timer1.Enabled == true)
                return;
            


            if (clickedLabel != null)
            {
                // Se o marcador clicado for preto, o player clicou
                // um ícone que já foi revelado --
                // ignora o clique
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                // Se firstClicked for null, este é o primeiro ícone
                // no par que o jogador clicou,
                // então defina firstClicked para o rótulo que o jogador
                // clicado, muda sua cor para preto e retorna
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                // Se o jogador chegar até aqui, o cronômetro não está
                // running e firstClicked não é nulo,
                // então este deve ser o segundo ícone que o jogador clicou
                // Define sua cor para 
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                // Se o jogador chegar até aqui, o cronômetro não está
                // running e firstClicked não é nulo,
                // então este deve ser o segundo ícone que o jogador clicou
                // Define sua cor para preto
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Check to see if the player won
                CheckForWinner();

                // Se o jogador clicou em dois ícones correspondentes, mantenha-os
                // preto e redefinir firstClicked e secondClicked
                // para que o jogador possa clicar em outro ícone
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // Se o jogador chegar até aqui, o jogador
                // clicou em dois ícones diferentes, então inicie o
                // timer (que vai esperar três quartos de
                // um segundo e, em seguida, ocultar os ícones)
                timer1.Start();

            }
            
        }


        // firstClicked aponta para o primeiro controle Label
        // que o jogador clica, mas será nulo
        // se o player ainda não clicou em um marcador
        Label firstClicked = null;

        // secondClicked aponta para o segundo controle Label
        // que o jogador clica
        Label secondClicked = null;

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset firstClicked and secondClicked 
            // so the next time a label is
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;


        }
        

                
    private void CheckForWinner()
        {
            // Go through all of the labels in the TableLayoutPanel, 
            // checking each one to see if its icon is matched
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            // If the loop didn’t return, it didn't find
            // any unmatched icons
            // That means the user won. Show a message and close the form
            MessageBox.Show("Você achpu todos os pares", "Parabénse");
            Close();


        }




             
    }

}
