using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scalextric
{
    public partial class FormHome : Form
    {
        private static readonly int MAX_CARS = 6;
        private static readonly string DATA_FILE = "data.xml";
        private static readonly Color START_BUTTON_COLOUR = Color.Green;
        private static readonly Color STOP_BUTTON_COLOUR = Color.Firebrick;

        private Race race;
        private Car[] availableCars = new Car[MAX_CARS];
        private FormRace frmRace = null;
        private TrackConnection connection;

        public FormHome()
        {
            InitializeComponent();
            cmboRaceType.SelectedIndex = 0;
            if (File.Exists(DATA_FILE))
            {
                dsSlots.ReadXml(DATA_FILE);
            }
            UpdateCarDB();
            chkRaceAll.Checked = true;
        }

        /// <summary>
        /// Event handler for FormLoad.
        /// Calls UpdateDriverDisplay()
        /// Sets the ComboBoxes for driver selection for all the cars.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormHome_Load(object sender, EventArgs e)
        {
            UpdateDriverDisplay();
            cmboDriver1.SelectedIndex = -1;
            cmboDriver2.SelectedIndex = -1;
            cmboDriver3.SelectedIndex = -1;
            cmboDriver4.SelectedIndex = -1;
            cmboDriver5.SelectedIndex = -1;
            cmboDriver6.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for FormClosing
        /// Disconnects the TrackConnection Instance to stop the comms thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null)
            {
                connection.Disconnect();
            }
        }

       /// <summary>
        /// This function initialises the available cars with information saved in the DtRaceCar datatable.
        /// If the car datatable is incomplete, this function rebuilds the car datatable and initialises the available cars with default values
        /// </summary>
        private void UpdateCarDB()
        {
            if (dsSlots.DtRaceCar.Rows.Count < MAX_CARS)
            {
                dsSlots.DtRaceCar.Rows.Clear();

                for (int i = 0; i < availableCars.Length; i++)
                {
                    availableCars[i] = new Car();
                    availableCars[i].ID = i + 1;
                    DsSlots.DtRaceCarRow row = dsSlots.DtRaceCar.NewDtRaceCarRow();
                    availableCars[i].GetData(ref row);
                    dsSlots.DtRaceCar.Rows.Add(row);
                }
            }
            else
            {
                for (int i = 0; i < availableCars.Length; i++)
                {
                    availableCars[i] = new Car((DsSlots.DtRaceCarRow)dsSlots.DtRaceCar.Rows[i]);
                }
            }
            
            pnlColour1.BackColor = (availableCars[0].Colour.Name == Color.Empty.Name) ? Color.White : availableCars[0].Colour;
            pnlColour2.BackColor = (availableCars[1].Colour.Name == Color.Empty.Name) ? Color.White : availableCars[1].Colour;
            pnlColour3.BackColor = (availableCars[2].Colour.Name == Color.Empty.Name) ? Color.White : availableCars[2].Colour;
            pnlColour4.BackColor = (availableCars[3].Colour.Name == Color.Empty.Name) ? Color.White : availableCars[3].Colour;
            pnlColour5.BackColor = (availableCars[4].Colour.Name == Color.Empty.Name) ? Color.White : availableCars[4].Colour;
            pnlColour6.BackColor = (availableCars[5].Colour.Name == Color.Empty.Name) ? Color.White : availableCars[5].Colour;
            
            dsSlots.WriteXml(DATA_FILE);
        }

        /// <summary>
        /// This function displays images in the Driver DatagridView using the image file name stored in the DtDriver table
        /// </summary>
        private void UpdateDriverDisplay()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    row.Cells["colIcon"].Value = Image.FromFile((string)row.Cells["colImage"].Value);
                }
                catch { }
            }
        }

        /// <summary>
        /// Event handler for Setup menu button
        /// Opens an instance of FormConnection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConnection frmConnection = new FormConnection();
            frmConnection.ShowDialog();
        }

        /// <summary>
        /// Event handler for Connect menu button
        /// Initialises connection as a new TrackConnection instance using the selected serial port
        /// Sets Cars in connection to availableCars.
        /// Initialises race as a new instance of Race using connection.
        /// Starts the connection's comms thread.
        /// If connection was allready started, it stops the connection
        /// Also enables/disables the Race GroupBox and sets the text on the menu button to reflect the connection status  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectToolStripMenuItem.Text == "Connect")
            {
                string port = Properties.Settings.Default.SerialPort;
                string[] ports = SerialPort.GetPortNames();

                if (!ports.Contains(port))
                {
                    MessageBox.Show(this, "No valid serial port selected");
                }
                else
                {
                    connection = new TrackConnection(port);
                    connection.SetCars(ref availableCars);
                    //race = new RaceOld(connection);
                    connection.Connect();
                    gbRace.Enabled = true;
                    connectToolStripMenuItem.Text = "Disconnect";
                    connection.StartTiming();
                    connection.PauseTiming();
                }
            }
            else
            {
                if (connection != null)
                {
                    connection.Disconnect();
                }
                gbRace.Enabled = false;
                connectToolStripMenuItem.Text = "Connect";
            }
        }

        /// <summary>
        /// Event handler for the Add driver button.
        /// Opens the an instance of FormDriver to capture driver info and then inserts the info into the DtDriver table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDriver_Click(object sender, EventArgs e)
        {
            FormDriver frmDriver = new FormDriver();
            if (frmDriver.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DsSlots.DtDriverRow row = dsSlots.DtDriver.NewDtDriverRow();
                row.Name = frmDriver.Drivername;
                row.Image = frmDriver.Icon;
                dsSlots.DtDriver.AddDtDriverRow(row);

                dsSlots.WriteXml(DATA_FILE);
                UpdateDriverDisplay();
            }
        }

        /// <summary>
        /// Event handler for the Delete Driver Button
        /// Removes the selected driver from the DtDriver table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDriver_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete the selected driver?", "Delete Driver", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataRow row = ((DataRowView)dataGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
                    row.Delete();
                    dsSlots.WriteXml(DATA_FILE);
                }
            }
        }

        /// <summary>
        /// Event handler for the Edit Driver button
        /// Opens an instance of Form driver populated with the information from the selected driver
        /// Any changes made is saved to the database when the user clicks OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditDriver_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DsSlots.DtDriverRow row = (DsSlots.DtDriverRow)((DataRowView)dataGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
                FormDriver frmDriver = new FormDriver(row.Name,row.Image);
                if (frmDriver.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    row.Name = frmDriver.Drivername;
                    row.Image = frmDriver.Icon;
                    UpdateDriverDisplay();

                    dsSlots.WriteXml(DATA_FILE);
                }
                
            }
        }

        /// <summary>
        /// Event handler for sort Driver DataGridView sort.
        /// Only calls the UpdateDriverDisplay() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            UpdateDriverDisplay();
        }

        /// <summary>
        /// Event handler for all the Car Setup buttons
        /// Opens an instance of FormCarSetup and populates with information saved for the apropriate car.
        /// Any changes made are saved to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetup_Click(object sender, EventArgs e)
        {
            DsSlots.DtRaceCarRow rowToUpdate;
            Car carToUpdate;
            FormCarSetup frmSetup;
            Panel panelToColour;
            if (sender == btnSetup1)
            {
                carToUpdate = availableCars[0];
                rowToUpdate = (DsSlots.DtRaceCarRow)dsSlots.DtRaceCar.Rows[0];
                panelToColour = pnlColour1;
            }
            else if (sender == btnSetup2)
            {
                carToUpdate = availableCars[1];
                rowToUpdate = (DsSlots.DtRaceCarRow)dsSlots.DtRaceCar.Rows[1];
                panelToColour = pnlColour2;
            }
            else if (sender == btnSetup3)
            {
                carToUpdate = availableCars[2];
                rowToUpdate = (DsSlots.DtRaceCarRow)dsSlots.DtRaceCar.Rows[2];
                panelToColour = pnlColour3;
            }
            else if (sender == btnSetup4)
            {
                carToUpdate = availableCars[3];
                rowToUpdate = (DsSlots.DtRaceCarRow)dsSlots.DtRaceCar.Rows[3];
                panelToColour = pnlColour4;
            }
            else if (sender == btnSetup5)
            {
                carToUpdate = availableCars[4];
                rowToUpdate = (DsSlots.DtRaceCarRow)dsSlots.DtRaceCar.Rows[4];
                panelToColour = pnlColour5;
            }
            else
            {
                carToUpdate = availableCars[5];
                rowToUpdate = (DsSlots.DtRaceCarRow)dsSlots.DtRaceCar.Rows[5];
                panelToColour = pnlColour6;
            }

            frmSetup = new FormCarSetup(carToUpdate);
            frmSetup.ShowDialog(this);
            panelToColour.BackColor = (carToUpdate.Colour.Name == Color.Empty.Name) ? Color.White : carToUpdate.Colour;

            carToUpdate.GetData(ref rowToUpdate);

            dsSlots.WriteXml(DATA_FILE);

        }

        /// <summary>
        /// Event handler for driver selection ComboBoxes for all the cars
        /// Creates an instance of Driver class and populates it with data from the selected driver dararow 
        /// and then adds the Driver instance to the apropriate car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ComboBox) && ((ComboBox)sender).SelectedIndex >= 0)
            {
                if (sender == cmboDriver1)
                {
                    Driver driver = new Driver((DsSlots.DtDriverRow)((DataRowView)cmboDriver1.SelectedItem).Row);
                    availableCars[0].Driver = driver;
                }
                else if (sender == cmboDriver2)
                {
                    Driver driver = new Driver((DsSlots.DtDriverRow)((DataRowView)cmboDriver2.SelectedItem).Row);
                    availableCars[1].Driver = driver;
                }
                else if (sender == cmboDriver3)
                {
                    Driver driver = new Driver((DsSlots.DtDriverRow)((DataRowView)cmboDriver3.SelectedItem).Row);
                    availableCars[2].Driver = driver;
                }
                else if (sender == cmboDriver4)
                {
                    Driver driver = new Driver((DsSlots.DtDriverRow)((DataRowView)cmboDriver4.SelectedItem).Row);
                    availableCars[3].Driver = driver;
                }
                else if (sender == cmboDriver5)
                {
                    Driver driver = new Driver((DsSlots.DtDriverRow)((DataRowView)cmboDriver5.SelectedItem).Row);
                    availableCars[4].Driver = driver;
                }
                else if (sender == cmboDriver6)
                {
                    Driver driver = new Driver((DsSlots.DtDriverRow)((DataRowView)cmboDriver6.SelectedItem).Row);
                    availableCars[5].Driver = driver;
                }
            }
        }

        /// <summary>
        /// Event handler for the Check all CheckBox
        /// Checks/unchecks all the car's CheckBoxes according to the Check All CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRaceAll_CheckedChanged(object sender, EventArgs e)
        {
            chkRace1.Checked = chkRaceAll.Checked;
            chkRace2.Checked = chkRaceAll.Checked;
            chkRace3.Checked = chkRaceAll.Checked;
            chkRace4.Checked = chkRaceAll.Checked;
            chkRace5.Checked = chkRaceAll.Checked;
            chkRace6.Checked = chkRaceAll.Checked;
        }

        /// <summary>
        /// Event handler for the RaceType ComboBox
        /// Enables/Disables controls that are associted with different race types
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmboRaceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLaps.Enabled = cmboRaceType.SelectedIndex == 1;
            nudLaps.Enabled = cmboRaceType.SelectedIndex == 1;

            lblTime.Enabled = cmboRaceType.SelectedIndex == 2;
            lblTimeMask.Enabled = cmboRaceType.SelectedIndex == 2;
            txtTime.Enabled = cmboRaceType.SelectedIndex == 2;
        }

        /// <summary>
        /// Event handler for race start button
        /// initialises new race by resetting the lapcouonts on all the cars, setting a new race type (and parameters) for race 
        /// and defining which cars will take art in the race based on check boxes.
        /// Then creates a new instance of FormRace and displays it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRaceStart_Click(object sender, EventArgs e)
        {
/*            if (race.TrackStatus.Status == RaceStatus.Paused || race.Status == RaceStatus.Stopped)
            {
                List<Car> cars = new List<Car>();
                RaceType raceType = (RaceType)cmboRaceType.SelectedIndex;
                race.RaceType = raceType;
                foreach (Car c in availableCars)
                {
                    c.ResetLapCount();
                    c.FuelLevel = 50;
                    c.UseFuel = chkUseFuel.Checked;
                }
                race.YellowFlagActSetting = (YelloFlagSetting)Properties.Settings.Default.YellowFlagActivation;
                if (chkUseFuel.Checked && race.YellowFlagActSetting == YelloFlagSetting.BrakeButton)
                {
                    race.YellowFlagActSetting = YelloFlagSetting.StartButton;
                }
                if (raceType == RaceType.F1)
                {
                    race.LapsToRace = (int)nudLaps.Value;
                }
                else if (raceType == RaceType.Endurance)
                {
                    TimeSpan timeToRace = TimeSpan.Parse(txtTime.Text);
                    race.TimeToRace = timeToRace;
                }

                if (raceType == RaceType.Practice)
                {
                    race.Cars = availableCars;
                }
                else
                {
                    if (chkRace1.Checked) cars.Add(availableCars[0]);
                    if (chkRace2.Checked) cars.Add(availableCars[1]);
                    if (chkRace3.Checked) cars.Add(availableCars[2]);
                    if (chkRace4.Checked) cars.Add(availableCars[3]);
                    if (chkRace5.Checked) cars.Add(availableCars[4]);
                    if (chkRace6.Checked) cars.Add(availableCars[5]);

                    race.Cars = cars.ToArray();
                }

                frmRace = new FormRace(race);
                frmRace.FormClosed += frmRace_FormClosed;
                btnRaceStart.BackColor = STOP_BUTTON_COLOUR;
                btnRaceStart.Text = "Stop Race";
                frmRace.Show();
            }
            else
            {
                frmRace.Close();
            }*/
        }

        void frmRace_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmRace.FormClosed -= frmRace_FormClosed;
            //race.StopRace();
            btnRaceStart.BackColor = START_BUTTON_COLOUR;
            btnRaceStart.Text = "Start Race";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void raceSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRaceSetup frmRs = new FormRaceSetup();
            frmRs.ShowDialog(this);
        }

    }
}
