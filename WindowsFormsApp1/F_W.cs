using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using RestSharp;
using Newtonsoft.Json;// add deserializer
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class F_W : Form
    {
        Recipe[] recipeResponse;// need the array aceesable for all of the button clicks. 
        int refreshCounter = 0;// need this to be global so we can have the correct indexes for each image if the new reciep search is pressed.used in the new reciep search button function.

        public F_W()
        {
            InitializeComponent();

            //set up formatting of picture box.
            showRecipes.Hide();
            recipe1Image.SizeMode = PictureBoxSizeMode.StretchImage;// will ensure the picture will fit into the box.
            recipe2Image.SizeMode = PictureBoxSizeMode.StretchImage;
            recipe3Image.SizeMode = PictureBoxSizeMode.StretchImage;
            recipe4Image.SizeMode = PictureBoxSizeMode.StretchImage;
            panel1Wine.Hide();
            pictureBoxURLWine.SizeMode = PictureBoxSizeMode.StretchImage;

            textBoxWineInfo.ScrollBars = ScrollBars.Vertical;

        }
        // private void findRecipeButton_Click(object sender, EventArgs e)
        // {


        //private async void button1_Click_1(object sender, EventArgs e)
        //{
        private async void findRecipeButton_Click(object sender, EventArgs e)
        {
            if (TextBox1Ingredient1.textbox.Text.Length == 0 || TextBox1Ingredient2.textbox.Text.Length == 0 ||
                !Regex.IsMatch(TextBox1Ingredient1.textbox.Text, @"[a-zA-Z]") || !Regex.IsMatch(TextBox1Ingredient2.textbox.Text, @"[a-zA-Z]"))
                //VALIDATION
            {
                MessageBox.Show("Please enter a valid ingredient in both Ingredient windows", "Ingredient Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var API_KEY = "7dc1c78d28f94acf88e2f53778dabdac";
                var client1 = new RestClient("https://api.spoonacular.com/recipes/complexSearch/");
                var request1 = new RestRequest();

                // request1.AddParameter("cuisine", comboBox1CuisineType.Text);
                request1.AddParameter("apiKey", API_KEY);

                var response1 = await client1.ExecuteAsync(request1);


                var client = new RestClient("https://api.spoonacular.com/recipes/findByIngredients?ingredients=" + TextBox1Ingredient1.textbox.Text + ",+" + TextBox1Ingredient2.textbox.Text + "&apiKey=7dc1c78d28f94acf88e2f53778dabdac");//client is used as a new instance of the api.
                var request = new RestRequest();
                request.AddParameter("ignorePantry", false);


                //set up and build list of parameters
                //string myKey = "7dc1c78d28f94acf88e2f53778dabdac";
                var response = await client.ExecuteAsync(request);// await is a function to make an asyncronys call


                recipeResponse = JsonConvert.DeserializeObject<Recipe[]>(response.Content);// fetching it from teh json
                recipe1Name.Text = recipeResponse[0].title;
                recipe2Name.Text = recipeResponse[1].title;
                recipe3Name.Text = recipeResponse[2].title;
                recipe4Name.Text = recipeResponse[3].title;

                recipe1Image.Load(recipeResponse[0].image);// load() is a function to load an image from a url.
                recipe2Image.Load(recipeResponse[1].image);
                recipe3Image.Load(recipeResponse[2].image);
                recipe4Image.Load(recipeResponse[3].image);
                //textBox2DisplayInfo.Text = string.Join("\r\n",recipeResponse.Select(element=>element.title));// .Content is not a function in C sharp but it is a string build in rest sharp. 
                // like in teh foreach loop the word element can be any word it is just to describe the part of the arrays.
                label2RecipeCount.Text = "" + recipeResponse.Length + " recipes found. Choose your Recipe";
                showRecipes.Show();
                //textBox2DisplayInfo.Location = new Point(23, 400);// change location.
            }
        }

        private async void RecipeInstruction(int index)
        {
            
            var client = new RestClient("https://api.spoonacular.com/recipes/" + recipeResponse[index].id + "/analyzedInstructions?apiKey=7dc1c78d28f94acf88e2f53778dabdac");
            var request = new RestRequest();
            // need to do this as the pantry itens are being left out of the recipe. 
            var response = await client.ExecuteAsync(request);
            // we made the call to spoonacular and now we need to create a container to save the response and to deserialize. 
                       
            Instruction recipeInstructionResponse = JsonConvert.DeserializeObject<Instruction[]>(response.Content)[0];//response.Content will print the while json of instructions.

            textBox2DisplayInfo.Text = recipeResponse[index].title + "\r\n\r\n";
            // put 0 inside to reference the first instruction.
            // join every piece of the array with a \n and a ,.The join function has two elements and the comma separatees them. 


            //for (int i = 0; i < recipeInstructionResponse.steps.Count; i++)
            //{

            //    for (int j =0; j < recipeInstructionResponse.steps[i].ingredients.Count; j++)//steps is a list of class objects. 
            //        {
            //        textBox2DisplayInfo.Text += (j + 1)+ ":\r\t" + recipeInstructionResponse.steps[i].ingredients[j].name + "\r\n";// Need to access the elements in a class.
            //    }


            //}
            int counter = 1;
            textBox2DisplayInfo.Text += "Ingredients: \r\n\r\n";
            foreach (var ingredient in recipeResponse[0].usedIngredients)
            {
                textBox2DisplayInfo.Text += (counter++) + "\t" +ingredient.original + "\r\n";
            }

            foreach (var ingredient in recipeResponse[0].missedIngredients)
            {
                textBox2DisplayInfo.Text += (counter++) +  "\t"+ingredient.original + "\r\n";
            }
                    
            if(recipeInstructionResponse.steps == null)
            {
                textBox2DisplayInfo.Text += "There is no method for this receipe search\n\r\n\r"+ "Try entering new ingredients in the ingredient search window";

            }
            else
            {
                textBox2DisplayInfo.Text += "\r\nRecipe Method:\r\n\r\n";// need the plus equals as otherwise we will be deleting the content of the whole box.

                for (int i = 0; i < recipeInstructionResponse.steps.Count; i++)//i < should not <= as each reciep has a differtn amount of steps. We can reach count -1 but not count. 
                {
                    textBox2DisplayInfo.Text += (i + 1) + ":\r\t" + recipeInstructionResponse.steps[i].step + "\r\n";// steps is a list so we can use the square brackets to acess it.Steps is also a class

                }
            }

           
        } 
        private void recipe1Image_Click(object sender, EventArgs e)
        {
            RecipeInstruction(0);
        }

        private void recipe2Image_Click(object sender, EventArgs e)
        {
            RecipeInstruction(1);
        }

        private void recipe3Image_Click(object sender, EventArgs e)
        {
            RecipeInstruction(2);
        }

        private void recipe4Image_Click(object sender, EventArgs e)
        {
            RecipeInstruction(3);
        }

        private async void Button2WineSearch_Click(object sender, EventArgs e)
        {
            

            var API_KEY = "7dc1c78d28f94acf88e2f53778dabdac";
            var client2 = new RestClient("https://api.spoonacular.com/food/wine/pairing?food=" + TextBox1Ingredient1.textbox.Text);
            var request2 = new RestRequest();

           
            request2.AddParameter("apiKey", API_KEY);

            var response2= await client2.ExecuteAsync(request2);

            WineSearch wineSearch = new WineSearch();
            wineSearch = JsonConvert.DeserializeObject<WineSearch>(response2.Content);
            panel1Wine.Show();
            if(wineSearch.productMatches== null || wineSearch.productMatches.Count==0)// if the whole list is null-//VALIDATION
            {
                textBoxWineInfo.Text = "There was not no wine pairing for the ingredient search: " + TextBox1Ingredient1.textbox.Text +
                    "\r\n\r\nTry entering a different ingredient in the first ingredient selection window" +
                    "\r\n\r\nTry a protein such salmon, beans, beef etc.";
                pictureBoxURLWine.Load("https://i.imgur.com/fZOU1pY.png");
            }
            else
            {
                textBoxWineInfo.Text = wineSearch.pairingText + "\r\n\r\n" + wineSearch.productMatches[0].title + "\r\n\r\nWine Price: "
           + wineSearch.productMatches[0].price + "\r\n\r\n" + wineSearch.productMatches[0].link;

                pictureBoxURLWine.Load(wineSearch.productMatches[0].imageUrl);
            }
           
        }

        private void Button3NewRecipeS_Click(object sender, EventArgs e)
        {
            textBox2DisplayInfo.Text = "";// it will clear the text box ready for the next receipe choice.
                                          // 
                                          // After refreshing we want to show four new receipes.
            refreshCounter += 4;// += to go onto the next set of results if there is not enough results need to show a message.
           

            if(recipeResponse.Length < 3 + refreshCounter +1 )// need the + 1 here to be bigger then what we have here. +1 is acting as a counter.
            {
                MessageBox.Show("There are no more recipies to display, Please enter new ingredient", "Recipe Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                recipe1Name.Text = recipeResponse[0 + refreshCounter].title;
                recipe2Name.Text = recipeResponse[1 + refreshCounter].title;
                recipe3Name.Text = recipeResponse[2 + refreshCounter].title;
                recipe4Name.Text = recipeResponse[3 + refreshCounter].title;

                recipe1Image.Load(recipeResponse[0 + refreshCounter].image);// load() is a function to load an image from a url.
                recipe2Image.Load(recipeResponse[1 + refreshCounter].image);
                recipe3Image.Load(recipeResponse[2 + refreshCounter].image);
                recipe4Image.Load(recipeResponse[3 + refreshCounter].image);
            }
        
        }
    }
}
