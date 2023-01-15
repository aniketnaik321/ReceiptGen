using Assimp;
using Avalonia.Controls;
using DotnetNoise;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Pdf.Exporting.XPS.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;
using Matrix4x4 = Assimp.Matrix4x4;
using Paragraph = Spire.Doc.Documents.Paragraph;


namespace POCProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the document
            Document document = new Document();
            document.LoadFromFile("C:\\Users\\anike\\OneDrive\\Desktop\\Resume.docx");

            List<Paragraph> originalParagraph = new List<Paragraph>();
            string tag = "<prj>";
            TextSelection[] skillsSelection = document.FindAllString("<prj>", true, true);


            // Search for the string
            //string searchString = "<prj>";
            //FindReplaceOptions options = new FindReplaceOptions();
            //options.MatchCase = true;
            //options.MatchWholeWord = true;
            //FindReplaceResult result = doc.Find(searchString, options);

            foreach (var item in skillsSelection)
            {
                TextRange text = item.GetAsOneRange();
                originalParagraph.Add(text.OwnerParagraph);

            }


            // Get the paragraph to be cloned
            // originalParagraph = document.Sections[0].Paragraphs[15];

            // MessageBox.Show(document.Sections[0].Paragraphs.IndexOf(originalParagraph).ToString());
            // Clone the paragraph

            for (int i = 0; i < 5; i++)
            {
                List<Paragraph> clonedParagraphs = new List<Paragraph>();
                foreach (Paragraph paragraph in originalParagraph)
                {
                    clonedParagraphs.Add((Paragraph)paragraph.Clone());
                }
                clonedParagraphs.Reverse();
                foreach (Paragraph clonedParagraph in clonedParagraphs)
                {
                    clonedParagraph.Replace("#spec#", "Diploma in Graphics Engineering" + i, false, false);
                    clonedParagraph.Replace(tag, string.Empty, false, false);
                    // Add the cloned paragraph to the document
                    document.Sections[0].Paragraphs.Insert(15, clonedParagraph);
                }
            }

            foreach (var item in originalParagraph)
            {
                document.Sections[0].Body.Paragraphs.Remove(item);
            }
            ///

            // Save the document
            document.SaveToFile("C:\\Users\\anike\\OneDrive\\Desktop\\Resumeout.docx", FileFormat.Docx);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            // Create a new Bitmap object with the specified width and height
            int width = 512;
            int height = 512;
            Bitmap image = new Bitmap(width, height);

            // Create a FastNoise object with the specified number of octaves and seed value
            FastNoise noise = new FastNoise(5000);

            // Iterate over each pixel in the image
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Generate a Perlin noise value for the current pixel
                    float value = Math.Abs(noise.GetPerlin(x, y));

                    // Use the noise value to set the color of the pixel
                    Color color = Color.FromArgb((int)(value * 255), (int)(value * 255), (int)(value * 255));
                    image.SetPixel(x, y, color);
                }
            }

            // Save the image to a file
            image.Save(@"C:\Users\anike\OneDrive\Desktop\perlin-noise.png");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int width = 1000;
            int height = 1000;

            // Create a new FastNoise object
            FastNoise noise = new FastNoise();

            // Set the noise type to Perlin
            noise.SetNoiseType(FastNoise.NoiseType.Perlin);

            // Create a new Bitmap object with the desired width and height
            Bitmap leafTexture = new Bitmap(width, height);

            // Create a new Graphics object from the bitmap
            Graphics graphics = Graphics.FromImage(leafTexture);

            // Set the graphics object's smoothing mode to high quality
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            // Create a new LinearGradientBrush for the leaf veins
            LinearGradientBrush veinBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(width, height),
                Color.FromArgb(0, 255, 0),  // start color (dark green)
                Color.FromArgb(0, 128, 0)   // end color (light green)
            );

            // Iterate over each pixel in the bitmap
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Generate the noise value for the current position
                    float noiseValue = Math.Abs(noise.GetNoise(x, y));

                    // Use the noise value to create a color based on a gradient map
                    Color pixelColor = Color.FromArgb(
                        255,                           // alpha
                        (int)(noiseValue * 255),       // red
                        (int)(noiseValue * 255),       // green
                        (int)(noiseValue * 128)        // blue
                    );

                    // Set the pixel color to the gradient color
                    leafTexture.SetPixel(x, y, pixelColor);

                    // Draw the leaf veins over the pixel using the vein brush
                    graphics.FillEllipse(veinBrush, x, y, 3, 3);
                }
            }

            // Save the leaf texture to a file
            leafTexture.Save(@"C:\Users\anike\OneDrive\Desktop\leaf_texture.png", ImageFormat.Png);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create a new FastNoise object
            FastNoise noise = new FastNoise();
            int width = 500;
            int height = 500;

            // Set the noise type to Perlin
            noise.SetNoiseType(FastNoise.NoiseType.Perlin);

            // Create a new Bitmap object with the desired width and height
            Bitmap curvedTexture = new Bitmap(width, height);

            // Iterate over each pixel in the bitmap
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Calculate the distance from the center of the bitmap
                    float distance = Vector2.Distance(new Vector2(x, y), new Vector2(width / 2, height / 2));

                    // Calculate the noise value for the current position
                    float noiseValue = Math.Abs(noise.GetNoise(x, y));

                    // Use the distance and noise value to create a color based on a gradient map
                    Color pixelColor = Color.FromArgb(
                        255,                           // alpha
                        (int)(distance / width * 255), // red
                        (int)(noiseValue * 255),       // green
                        (int)(distance / width * 128)  // blue
                    );

                    // Set the pixel color to the gradient color
                    curvedTexture.SetPixel(x, y, pixelColor);
                }
            }

            // Save the curved texture to a file
            curvedTexture.Save(@"C:\Users\anike\OneDrive\Desktop\curved_texture.png", ImageFormat.Png);
        }

        //private void button6_Click(object sender, EventArgs e)
        //{

        //        // Load the image into a Bitmap object
        //        Bitmap image = new Bitmap("image.png");

        //        // Create a new Assimp context
        //        AssimpContext assimpContext = new AssimpContext();

        //        // Create a new scene object
        //        Scene scene = new Scene();

        //        // Set the scene's root node to a new Node object
        //        scene.RootNode = new Node();

        //        // Iterate over each pixel in the image
        //        for (int x = 0; x < image.Width; x++)
        //        {
        //            for (int y = 0; y < image.Height; y++)
        //            {
        //                // Get the pixel color at the current position
        //                Color pixelColor = image.GetPixel(x, y);

        //                // Create a new mesh with a single vertex
        //                Mesh mesh = new Mesh();
        //                mesh.Vertices.Add(new Vector3D(x, y, pixelColor.B / 255.0));  // Z value is based on blue channel
        //                mesh.Faces.Add(new Face(0));  // Add a single face to the mesh

        //                // Create a new mesh part for the mesh
        //                 MeshPart meshPart = new MeshPart();
        //                meshPart.BaseVertex = 0;
        //                meshPart.NumVertices = 1;
        //                meshPart.MaterialIndex = 0;

        //                // Add the mesh part to the mesh
        //                mesh.MeshParts.Add(meshPart);

        //                // Create a new node for the mesh
        //                Node meshNode = new Node();
        //                meshNode.Name = "MeshNode";
        //                meshNode.MeshIndices.Add(0);  // Add the mesh to the node
        //                meshNode.Transform = Matrix4x4.Identity;  // Set the node's transform to the identity matrix

        //                // Add the mesh node to the scene's root node
        //                scene.RootNode.Children.Add(meshNode);

        //                // Add the mesh to the scene
        //                scene.Meshes.Add(mesh);
        //            }
        //        }

        //        // Export the scene to a OBJ file
        //        assimpContext.ExportFile(scene, "model.obj", "obj");
        //    }
        //}
    }
}



