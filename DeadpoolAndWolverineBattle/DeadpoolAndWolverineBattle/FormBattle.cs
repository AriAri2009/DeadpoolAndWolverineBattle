using System;
using System.Drawing; 
using System.Threading.Tasks; 
using System.Windows.Forms;
namespace DeadpoolAndWolverineBattle
{
    public partial class FormBattle : Form
    {
        int hpDeadpool;
        int hpWolverine;
        bool mareoDeadpool;
        bool mareoWolverine;
        Random random = new Random();
        int turnopelea;

        Image deadpoolIdle = Image.FromFile("imagenes/QuietoDeadpool.gif");
        Image deadpoolAttack = Image.FromFile("imagenes/PeleaDeadpool.gif");
        Image deadpoolLose = Image.FromFile("imagenes/DerrotaDeadpool.gif");

        Image wolverineIdle = Image.FromFile("imagenes/QuietoWolverineOriginal.gif");
        Image wolverineAttack = Image.FromFile("imagenes/PeleaWolverineOriginal.gif");
        Image wolverineLose = Image.FromFile("imagenes/DerrotadoWolverineOriginal.gif");

        public FormBattle()
        {
            InitializeComponent();
            pic_D.Image = deadpoolIdle;
            pic_W.Image = wolverineIdle;

            // Ajustamos el tamaño para que no se corten las animaciones
            pic_D.SizeMode = PictureBoxSizeMode.Zoom;
            pic_W.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private async void btn_Pelear_Click(object sender, EventArgs e)
        {
            hpDeadpool = 1000;
            hpWolverine = 1000;
            mareoDeadpool = false;
            mareoWolverine = false;

            pic_D.Image = deadpoolIdle;
            pic_W.Image = wolverineIdle;

            txt_Desarrollo.Clear();
            btn_Pelear.Enabled = false; 

            int numeroTurno = 1;
           
            bool turnoDeDeadpool = random.Next(2) == 0;

            txt_Desarrollo.AppendText("¡LA BATALLA COMIENZA!\r\n");

            ActualizarHP();

            // Bucle principal: se repite mientras AMBOS sigan de pie
            while (hpDeadpool > 0 && hpWolverine > 0)
            {
                txt_Desarrollo.AppendText($"\r\n--- TURNO {numeroTurno} ---\r\n");

                if (turnoDeDeadpool)
                {
                    // Usamos await para que el bucle espere a que termine toda la secuencia del ataque
                    await TurnoDeadpool();
                }
                else
                {
                    await TurnoWolverine();
                }

                ActualizarHP();

                // Cambiamos el turno para el siguiente ciclo
                turnoDeDeadpool = !turnoDeDeadpool;
                numeroTurno++;

                // Pausa obligatoria de 1 segundo entre turnos (Requisito de la asignación)
                await Task.Delay(1000);
            }

            // Al salir del bucle, significa que alguien perdió
            DeterminarGanador();
            btn_Pelear.Enabled = true;
        }

        private async Task TurnoDeadpool()
        {
            txt_Desarrollo.AppendText("Ataca Deadpool: ");

            // REGLA: ¿Estaba mareado por recibir daño máximo en el turno anterior?
            if (mareoDeadpool)
            {
                txt_Desarrollo.AppendText("¡Pierde el turno recuperándose del mareo!\r\n");
                mareoDeadpool = false; // Se limpia el estado para el próximo turno
                return;
            }

            // REGLA: Evasión de Wolverine (20% de probabilidades de esquivar)
            if (random.Next(1, 101) <= 20)
            {
                txt_Desarrollo.AppendText("¡Wolverine esquivó la galleta de Deadpool con sus reflejos!\r\n");
                return;
            }

            // Cambiamos la animación visual al GIF de ataque
            pic_D.Image = deadpoolAttack;

            // REGLA: Daño aleatorio entre 10 y 100
            int dano = random.Next(10, 101);

            // REGLA: Recupera un 2% del daño recibido en cada turno
            int regenNormal = (int)(dano * 0.02);
            hpWolverine = hpWolverine - dano + regenNormal;

            txt_Desarrollo.AppendText($"¡Zarpazo directo! Causa {dano} pts de daño. (Wolverine regenera {regenNormal} pts por factor curativo).\r\n");

            // REGLA: Si el daño es el MÁXIMO (100)
            if (dano == 100)
            {
                int regenExtra = (int)(dano * 0.05); // Aumenta un 5% del daño recibido
                hpWolverine += regenExtra;
                mareoWolverine = true; // No atacará en el siguiente turno
                txt_Desarrollo.AppendText($"¡GOLPE CRÍTICO MÁXIMO! Wolverine queda mareado y regenera {regenExtra} pts extra.\r\n");
            }

            // Esperamos 800 milisegundos mostrando el GIF de ataque antes de volver a la normalidad
            await Task.Delay(800);
            pic_D.Image = deadpoolIdle;
        }

        // MÉTODO DE ATAQUE DE WOLVERINE
        private async Task TurnoWolverine()
        {
            txt_Desarrollo.AppendText("Ataca Wolverine: ");

            if (mareoWolverine)
            {
                txt_Desarrollo.AppendText("¡Pierde el turno recuperándose del mareo!\r\n");
                mareoWolverine = false;
                return;
            }

            // REGLA: Evasión de Deadpool (25% de probabilidades de esquivar)
            if (random.Next(1, 101) <= 25)
            {
                txt_Desarrollo.AppendText("¡Deadpool evadió el ataque con una pirueta!\r\n");
                return;
            }

            // Cambiamos la animación visual al GIF de ataque
            pic_W.Image = wolverineAttack;

            // REGLA: Daño aleatorio entre 10 y 120
            int dano = random.Next(10, 121);

            int regenNormal = (int)(dano * 0.02);
            hpDeadpool = hpDeadpool - dano + regenNormal;

            txt_Desarrollo.AppendText($"¡Corte de katanas! Causa {dano} pts de daño. (Deadpool regenera {regenNormal} pts por factor curativo).\r\n");

            // REGLA: Si el daño es el MÁXIMO (120)
            if (dano == 120)
            {
                int regenExtra = (int)(dano * 0.05);
                hpDeadpool += regenExtra;
                mareoDeadpool = true;
                txt_Desarrollo.AppendText($"¡GOLPE CRÍTICO MÁXIMO! Deadpool queda mareado y regenera {regenExtra} pts extra.\r\n");
            }

            await Task.Delay(800);
            pic_W.Image = wolverineIdle;
        }

        // MÉTODO PARA ACTUALIZAR LOS TEXTOS DE VIDA EN LA INTERFAZ
        private void ActualizarHP()
        {
            lbl_pDead.Text = $"HP Deadpool: {(hpDeadpool < 0 ? 0 : hpDeadpool)}";
            lbl_pWol.Text = $"HP Wolverine: {(hpWolverine < 0 ? 0 : hpWolverine)}";

            // Autoscroll del TextBox para que siempre ruede hacia el texto más nuevo
            txt_Desarrollo.SelectionStart = txt_Desarrollo.Text.Length;
            txt_Desarrollo.ScrollToCaret();
        }

        // REQUISITO: MOSTRAR RESULTADO FINAL Y ASIGNAR ANIMACIONES DE DERROTA
        private void DeterminarGanador()
        {
            txt_Desarrollo.AppendText("\r\n=================================\r\n");

            if (hpDeadpool <= 0 && hpWolverine <= 0)
            {
                txt_Desarrollo.AppendText("¡MUTUO K.O.! Es un empate épico.\r\n");
                pic_D.Image = deadpoolLose;
                pic_W.Image = wolverineLose;
            }
            else if (hpDeadpool <= 0)
            {
                txt_Desarrollo.AppendText("¡WOLVERINE GANA LA BATALLA DE INMORTALES!\r\n");
                pic_D.Image = deadpoolLose; // Deadpool derrotado
                pic_W.Image = wolverineIdle; // Wolverine queda en espera celebrando
            }
            else
            {
                txt_Desarrollo.AppendText("¡DEADPOOL GANA LA BATALLA DE INMORTALES!\r\n");
                pic_D.Image = wolverineLose; // Wolverine derrotado
                pic_W.Image = deadpoolIdle;  // Deadpool queda en espera celebrando
            }
            txt_Desarrollo.AppendText("=================================\r\n");
        }
    }
    
}
