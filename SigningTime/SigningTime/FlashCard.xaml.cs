﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SigningTime
{
    public partial class FlashCard : ContentPage
    {

        private Sign sign;

        public FlashCard(Sign sign, int cardNumber)
        {
            this.sign = sign;

            InitializeComponent();

            // Sets up the current Page with correct values
            signName.Text = sign.Name.ToUpper() + " (card: " + cardNumber + ")";

            if(sign.Description != null){
                signDescription.Text = sign.Description;
            }
            // signDescription.Text = sign.Description;


            // Can't have a resoruce image file with name "new", so need to
            // handle when the new sign and add '_' to the name for the img file
            if(sign.Name.Equals("New")){
                signImage.Source = sign.Name.ToLower() + "_";
            }
            else{
                signImage.Source = sign.Name.ToLower();
            }

            // signImage.Source = "eat";
        }

        /// <summary>
        /// Launches the SignDemonstration page for this sign
        /// </summary>
        async void SignDemonstration(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignDemonstration(sign));
        }

        /// <summary>
        /// Flips a card to the other side.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void FlipCard(object sender, System.EventArgs e)
        {
            uint speed = 550;

            await wholePage.RotateYTo(-90, speed, Easing.SpringIn);
            wholePage.RotationY = -270;
            await wholePage.RotateYTo(-360, speed, Easing.SpringOut);
            wholePage.RotationY = 0;
        }
    }
}