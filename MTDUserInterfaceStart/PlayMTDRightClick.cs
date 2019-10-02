using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominoClassLiberary;

namespace MTDUserInterface
{
    public partial class PlayMTDRightClick : Form
    {
        #region instance_variables
        BoneYard boneYard;
        Hand computer, player;
        MainTrain maintrain;
        PrivateTrain computerTrain, playerTrain;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        int indexOfDominoInPlay = -1;
        Domino userDominoInPlay = null;
        List<PictureBox> mextrainpbs = new List<PictureBox>();
        List<PictureBox> playertrainpbs = new List<PictureBox>();
        List<PictureBox> comptrainpbs = new List<PictureBox>();


        #endregion

        #region Methods

        // loads the image of a domino into a picture box
        // verify that the path for the domino files is correct
        private void LoadDomino(PictureBox pb, Domino d)
        {
            pb.Image = Image.FromFile(System.Environment.CurrentDirectory
                        + "\\..\\..\\Dominos\\" + d.Filename);
        }

        // loads all of the dominos in a hand into a list of pictureboxes
        private void LoadHand(List<PictureBox> pbs, Hand h)
        {
            for (int i = 0; i < h.listOfDominos.Count; i++)
            {
                //PictureBox pb = pbs[i];
                //Domino d = h.listOfDominos[i];
                //LoadDomino(pb, d);
            }
        }

        // dynamically creates the "next" picture box for the user's hand
        // the instance variable nextDrawIndex should be passed as a parameter
        // if you change the layout of the form, you'll have to change the math here
        private PictureBox CreateUserHandPB(int index)
        {
            PictureBox pb = new PictureBox();
            pb.Visible = true;
            pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pb.Location = new System.Drawing.Point(24 + (index % 5) * 110, 366 + (index / 5) * 60);
            pb.Size = new System.Drawing.Size(100, 50);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Controls.Add(pb);
            return pb;
        }

        // adds the mouse down event handler to a picture box
        private void EnableHandPB(PictureBox pb)
        {
            pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.handPB_MouseDown);
        }

        // adds the mouse down event handler to all of the picture boxes in the users hand pb list
        private void EnableUserHandPBs(List<PictureBox> userHandPBs)
        {
            for (int i = 0; i < userHandPBs.Count; i++)
            {
                PictureBox pb = userHandPBs[i];
                EnableHandPB(pb);
            }
        }

        // removes the mouse down event handler from a picture box
        private void DisableHandPB(PictureBox pb)
        {
            pb.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.handPB_MouseDown);
        }

        // removes all of the mouse down event handlers from the picture boxes in the users hand pb list
        private void DisableUserHandPBs(List<PictureBox> userHandPBs)
        {
            for (int i = 0; i < userHandPBs.Count; i++)
            {
                PictureBox pb = userHandPBs[i];
                DisableHandPB(pb);
            }
        }

        // unloads the domino image from a picture box in a train
        public void RemoveDominoFromPB(int index, List<PictureBox> pBs)
        {
            PictureBox pB = pBs[index];
            pB.Image = null;
        }

        // removes a picture box from the form dynamically
        public void RemovePBFromForm(PictureBox pb)
        {
            this.Controls.Remove(pb);
            pb = null;
        }

        // plays a domino on a train.  Loads the appropriate train pb, 
        // removes the domino pb from the hand, updates the train status label ,
        // disables the hand pbs and disables appropriate buttons
        public void UserPlayOnTrain(Domino d, MainTrain train, List<PictureBox> trainPBs)
        {
            bool pbfilled = false;
            bool mustFlip;
            train.IsPlayable(d, out mustFlip);
            train.Play(d);
            player.listOfDominos.Remove(d);

            foreach (PictureBox pb in trainPBs)
            {
                if (pb.Image == null)
                {
                    LoadDomino(pb, d);
                    if(mustFlip == true)
                    {
                        PictureBox temp = new PictureBox();
                        temp.Image = pb.Image;
                        temp.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        pb.Image = temp.Image;
                        mustFlip = false;
                    }
                    break;
                }
                if (trainPBs.IndexOf(pb)== 4)
                {
                    pbfilled = true;
                }
                
                
            }
            foreach (PictureBox pb in trainPBs)
            { 
                
                if (pbfilled== true)
                {
                    int index = trainPBs.IndexOf(pb);
                    if (index == 4)
                    {
                        LoadDomino(pb, d);
                        if (mustFlip == true)
                        {
                            PictureBox temp = new PictureBox();
                            temp.Image = pb.Image;
                            temp.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            pb.Image = temp.Image;
                            mustFlip = false;
                        }
                        break;
                    }
                    else
                    {
                        pb.Image = trainPBs[index + 1].Image;
                        
                    }
                    
                }
            }
            
                ReloadPBS();
            EnableUserHandPBs(pictureBoxes);
        }

        // adds a domino picture to a train
        public void ComputerPlayOnTrain(Domino d, MainTrain train, List<PictureBox> trainPBs, int pbIndex)
        {
        }

        // ai for computer move.
        // calls play for on the computer's hand for each train, gets the next pb index and 
        // plays the domino on the train.  
        // BECAUSE play throws an exception, tries to first play on one train and
        // in the catch block tries the next and so on
        // when the computer can not play on any train, the computer draws and returns false.
        // if the method is called with canDraw = false, this last step is omitted and the method
        // returns false
        public bool MakeComputerMove(bool canDraw)
        {
            return true;
        }

        // update labels on the UI and disable the users hand
        // call MakeComputerMove (maybe twice)
        // update the labels on the UI
        // determine if the computer won or if it's now the user's turn
        public void CompleteComputerMove()
        {
        }

        // enable the hand pbs, buttons and update labels on the UI
        public void EnableUserMove()
        {
            EnableUserHandPBs(pictureBoxes);
        }

        // instantiate boneyard and hands
        // find the highest double in each hand
        // determine who should go first, remove the highest double from the appropriate hand
        // and display the highest double in the UI
        // instantiate trains now that you know the engine value
        // create all of the picture boxes for the user's hand and load the dominos for the hand
        // Add the picture boxes for each train to the appropriate list of picture boxes
        // update the labels on the UI
        // if it's the computer's turn, let her play
        // if it's the user's turn, enable the pbs so she can play
        public Domino biggestDomino(Hand h, out int index)
        {
            int count = -1;
            index = -1;
            Domino biggestdom = null;
            foreach (Domino domino in h.Dominos)
            {
                count += 1;
                if (domino.IsDouble())
                {
                    if (biggestdom != null)
                    {
                        if (domino.Side1 > biggestdom.Side1)
                        {
                            index = count;
                            biggestdom = domino;

                        }
                    }
                    else
                    {
                        index = count;
                        biggestdom = domino;
                    }
                }
            }

            return biggestdom;

        }
        public void PopulateTrainPBS()
        {
            mextrainpbs.Add(mexTrainPB1); mextrainpbs.Add(mexTrainPB2); mextrainpbs.Add(mexTrainPB3); mextrainpbs.Add(mexTrainPB4); mextrainpbs.Add(mexTrainPB5);
            playertrainpbs.Add(userTrainPB1); playertrainpbs.Add(userTrainPB2); playertrainpbs.Add(userTrainPB3); playertrainpbs.Add(userTrainPB4); playertrainpbs.Add(userTrainPB5);
            comptrainpbs.Add(compTrainPB1); comptrainpbs.Add(compTrainPB2); comptrainpbs.Add(compTrainPB3); comptrainpbs.Add(compTrainPB4); comptrainpbs.Add(compTrainPB5);
        }
        public void SetUp()
        {
            PopulateTrainPBS();
            
            Domino biggestdomino = null;
            EnableUserMove();
            boneYard = new BoneYard(9);
            boneYard.Shuffle();
            player = new Hand(boneYard);
            for (int i = 0; i < player.listOfDominos.Count(); i++)
            {
                PictureBox temp = CreateUserHandPB(i);
                pictureBoxes.Add(temp);
                LoadDomino(temp, player.listOfDominos[i]);

            }
            computer = new Hand(boneYard);
            int index;
            int caseSwitch = -1;
            Domino pldom = biggestDomino(player, out index);
            Domino comdom = biggestDomino(computer, out index);
            if (pldom == null && comdom == null)
            {
                caseSwitch = 1;
            }
            else if (pldom == null)
            {
                caseSwitch = 2;
            }
            else if (comdom == null)
            {
                caseSwitch = 3;
            }

            switch (caseSwitch)
            {
                case 1:
                    biggestdomino = null;
                    break;
                case 2:
                    biggestdomino = comdom;
                    computer.listOfDominos.Remove(biggestdomino);
                    break;
                case 3:
                    biggestdomino = pldom;
                    //indexOfDominoInPlay = index;
                    player.listOfDominos.Remove(biggestdomino);
                    //RemovePBFromForm(pictureBoxes[index]);
                    ReloadPBS();
                    break;
                default:
                    if (pldom.Side1 > comdom.Side1)
                    {
                        biggestdomino = pldom;
                        //indexOfDominoInPlay = index;
                        player.listOfDominos.Remove(biggestdomino);
                        //RemovePBFromForm(pictureBoxes[index]);
                        ReloadPBS();
                    }
                    else if (pldom.Side1 < comdom.Side1)
                    {
                        biggestdomino = comdom;
                        computer.listOfDominos.Remove(biggestdomino);
                    }
                    else
                    {
                        biggestdomino = null;
                    }
                    break;
            }

            

            if (biggestdomino == null)
            {
                TearDown();
                SetUp();
            }
            else
            {
                maintrain = new MainTrain(biggestdomino.Side1);
                playerTrain = new PrivateTrain(player, biggestdomino.Side1);
                computerTrain = new PrivateTrain(computer, biggestdomino.Side1);
                LoadDomino(enginePB, biggestdomino);
            }
            EnableUserHandPBs(pictureBoxes);

        }
        public void ReloadPBS()
        {
            for (int i = 0; i < pictureBoxes.Count(); i++)
            {
                RemovePBFromForm(pictureBoxes[i]);
            }
            pictureBoxes = new List<PictureBox>();
            for (int i = 0; i < player.listOfDominos.Count(); i++)
            {
                PictureBox temp = CreateUserHandPB(i);
                pictureBoxes.Add(temp);
                LoadDomino(temp, player.listOfDominos[i]);

            }
        }
        // remove all of the domino pictures for each train
        // remove all of the domino pictures for the user's hand
        // reset the nextDrawIndex to 15
        public void TearDown()
        {
            for (int i = 0; i < pictureBoxes.Count(); i++)
            {
                RemovePBFromForm(pictureBoxes[i]);
            }
            player = null;
            //pictureBoxes = null;
            pictureBoxes = new List<PictureBox>();

        }
        #endregion


        public PlayMTDRightClick()
        {
            InitializeComponent();
            SetUp();

        }

        // when the user right clicks on a domino, a context sensitive menu appears that
        // let's the user know which train is playable.  Green means playable.  Red means not playable.
        // the event handler for the menu item is enabled and disabled appropriately.
        private void whichTrainMenu_Opening(object sender, CancelEventArgs e)
        {


            bool mustFlip = false;
            if (userDominoInPlay != null)
            {
                mexicanTrainItem.Click -= new System.EventHandler(this.mexicanTrainItem_Click);
                computerTrainItem.Click -= new System.EventHandler(this.computerTrainItem_Click);
                myTrainItem.Click -= new System.EventHandler(this.myTrainItem_Click);
                Hand userHand = player;

                if (maintrain.IsPlayable(/*userHand,*/ userDominoInPlay, out mustFlip))
                {
                    mexicanTrainItem.ForeColor = Color.Green;
                    mexicanTrainItem.Click += new System.EventHandler(this.mexicanTrainItem_Click);
                }
                else
                {
                    mexicanTrainItem.ForeColor = Color.Red;
                }
                if (computerTrain.IsPlayable(userHand, userDominoInPlay, out mustFlip))
                {
                    computerTrainItem.ForeColor = Color.Green;
                    computerTrainItem.Click += new System.EventHandler(this.computerTrainItem_Click);
                }
                else
                {
                    computerTrainItem.ForeColor = Color.Red;
                }
                if (playerTrain.IsPlayable(userHand, userDominoInPlay, out mustFlip))
                {
                    myTrainItem.ForeColor = Color.Green;
                    myTrainItem.Click += new System.EventHandler(this.myTrainItem_Click);
                }
                else
                {
                    myTrainItem.ForeColor = Color.Red;
                }
            }

        }

        // displays the context sensitve menu with the list of trains
        // sets the instance variables indexOfDominoInPlay and userDominoInPlay
        private void handPB_MouseDown(object sender, MouseEventArgs e)
        {

            PictureBox handPB = (PictureBox)sender;
            indexOfDominoInPlay = pictureBoxes.IndexOf(handPB);
            if (indexOfDominoInPlay != -1)
            {
                userDominoInPlay = player.listOfDominos[indexOfDominoInPlay];
                if (e.Button == MouseButtons.Right)
                {
                    whichTrainMenu.Show(handPB,
                        handPB.Size.Width - 20, handPB.Size.Height - 20);
                }
            }

        }

        // play on the mexican train, lets the computer take a move and then enables
        // hand pbs so the user can make the next move.
        private void mexicanTrainItem_Click(object sender, EventArgs e)
        {
            UserPlayOnTrain(userDominoInPlay, maintrain, mextrainpbs);
           // maintrain.Play(userDominoInPlay);
            //player.listOfDominos.Remove(userDominoInPlay);
            
            //LoadDomino(mexTrainPB1, userDominoInPlay);
            //ReloadPBS();
            //EnableUserHandPBs(pictureBoxes);

        }

        // play on the computer train, lets the computer take a move and then enables
        // hand pbs so the user can make the next move.
        private void computerTrainItem_Click(object sender, EventArgs e)
        {
            if (computerTrain.IsOpen)
            {
                UserPlayOnTrain(userDominoInPlay, computerTrain, comptrainpbs);
            }
        }

        // play on the user train, lets the computer take a move and then enables
        // hand pbs so the user can make the next move.
        private void myTrainItem_Click(object sender, EventArgs e)
        {
            if (playerTrain.IsOpen) {
                
            }
            UserPlayOnTrain(userDominoInPlay, playerTrain, playertrainpbs);
        }

        // tear down and then set up
        private void newHandButton_Click(object sender, EventArgs e)
        {
            TearDown();
            SetUp();
        }

        // draw a domino, add it to the hand, create a new pb and enable the new pb
        private void drawButton_Click(object sender, EventArgs e)
        {
            player.Dominos.Add(boneYard.Draw());
            pictureBoxes.Add(CreateUserHandPB(player.listOfDominos.Count() - 1));
            LoadDomino(pictureBoxes[pictureBoxes.Count() - 1], player.listOfDominos[player.listOfDominos.Count() - 1]);
            EnableHandPB(pictureBoxes[pictureBoxes.Count() - 1]);
            /*CreateUserHandPB(player.listOfDominos.Count() - 1)*/
            playerTrain.Open();

        }

        // open the user's train, update the ui and let the computer make a move
        // enable the hand pbs so the user can make a move
        private void passButton_Click(object sender, EventArgs e)
        {

        }

        private void openOrClose_Click(object sender, EventArgs e)
        {
            if (computerTrain.IsOpen)
            {
                computerTrain.Close();
            }
            else computerTrain.Open();

        }

        private void PlayMTDRightClick_Load(object sender, EventArgs e)
        {
            // register the boneyard almost empty event and it's delegate here
        }

        // event handler for handling the boneyard almost empty event
        private void RespondToEmpty(BoneYard by)
        {
            MessageBox.Show("The Boneyard must be empty");
        }

    }
}
