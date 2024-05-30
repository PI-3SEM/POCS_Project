using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCS_Project.entities;

namespace POCS_Project.controllers
{
    public class ImageController
    {
        public void ModifyCardImageInsertValue(ref Image cardImage, Card cardData)
        {
            var grafic = Graphics.FromImage(cardImage);
            grafic.DrawString(
                Convert.ToString(cardData.Value),
                new Font("arial", 10F, FontStyle.Regular),
                Brushes.Black,
                new PointF(10, 5)
            );
            grafic.DrawString(
                Convert.ToString(cardData.Value),
                new Font("arial", 10F, FontStyle.Regular),
                Brushes.Black,
                new PointF(cardImage.Width - 10, 5)
            );
            grafic.Dispose();
        }

        public void TurnImageBlackAndWhite(ref Image originalImage)
        {
            using (Bitmap originalBitmap = new Bitmap(originalImage))
            {
                // Cria um novo bitmap para a imagem em preto e branco
                using (Bitmap grayscaleBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height))
                {
                    using (Graphics g = Graphics.FromImage(grayscaleBitmap))
                    {
                        // Cria uma matriz de cor em escala de cinza
                        ColorMatrix colorMatrix = new ColorMatrix(
                            new float[][]
                            {
                            new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                            new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                            new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                            });

                        // Cria atributos de imagem
                        ImageAttributes attributes = new ImageAttributes();
                        attributes.SetColorMatrix(colorMatrix);

                        // Desenha a imagem original no novo bitmap usando a matriz de cor em escala de cinza
                        g.DrawImage(originalBitmap, new Rectangle(0, 0, grayscaleBitmap.Width, grayscaleBitmap.Height),
                            0, 0, originalBitmap.Width, originalBitmap.Height, GraphicsUnit.Pixel, attributes);
                    }
                }
            }
        }
    }
}
