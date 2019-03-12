using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Plugin.Media.Abstractions;

namespace Directorio.Servicios
{
    public static class ServicioFace
    {
        static string key = "llave";
        static string endpoint = "https://westeurope.api.cognitive.microsoft.com/";
        // sin la version

        public static async Task<string> AnalizarFoto(MediaFile foto)
        {
            var mensaje = $"Rostro no detectado";

            try
            {
                if (foto != null)
                {
                    var credenciales = new ApiKeyServiceClientCredentials(key);
                    var handler = new DelegatingHandler[] { };

                    var cliente = new FaceClient(credenciales, handler);
                    cliente.Endpoint = endpoint;

                    var atributos = new FaceAttributeType[]
                    {
                        FaceAttributeType.Emotion,
                        FaceAttributeType.Age,
                        FaceAttributeType.Gender
                    };

                    using (var stream = foto.GetStream())
                    {
                        var listaFaces = await cliente.Face.DetectWithStreamAsync(stream, true, false, atributos);
                        var face = listaFaces.FirstOrDefault();

                        if (face != null)
                        {
                            var emocion = face.FaceAttributes.Emotion;
                            var maxScore = emocion.Anger;
                            var maxEmocion = "Ira";

                            if (emocion.Contempt > maxScore)
                            {
                                maxScore = emocion.Contempt;
                                maxEmocion = "Desprecio";
                            }

                            if (emocion.Disgust > maxScore)
                            {
                                maxScore = emocion.Disgust;
                                maxEmocion = "Disgusto";
                            }

                            if (emocion.Fear > maxScore)
                            {
                                maxScore = emocion.Fear;
                                maxEmocion = "Temor";
                            }

                            if (emocion.Happiness > maxScore)
                            {
                                maxScore = emocion.Happiness;
                                maxEmocion = "Felicidad";
                            }

                            if (emocion.Neutral > maxScore)
                            {
                                maxScore = emocion.Neutral;
                                maxEmocion = "Neutral";
                            }

                            if (emocion.Sadness > maxScore)
                            {
                                maxScore = emocion.Sadness;
                                maxEmocion = "Tristeza";
                            }

                            if (emocion.Surprise > maxScore)
                            {
                                maxScore = emocion.Surprise;
                                maxEmocion = "Sorpresa";
                            }

                            mensaje = $"Tu edad es {face.FaceAttributes.Age} años, eres {face.FaceAttributes.Gender} y tu emoción es {maxEmocion} ({maxScore})";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return mensaje;
        }
    }
}
