using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using UnityEngine.Advertisement;

/*
 * ПОКА НЕ ДОПИШУ НЕВНИКАЙТЕ!!
 */
namespace ShermanLibr
{ 
    public class Saver:MonoBehaviour
    {
        #region Serializable Class
        [System.Serializable]
        private class Int
        {
            public int @int;
        }

        [System.Serializable]
        private class String
        {
            public string @string;
        }

        [System.Serializable]
        private class Float
        {
            public float @float;
        }

        [System.Serializable]
        private class Double
        {
            public double @double;
           
        }

        [System.Serializable]
        private class Bool
        {
            public bool @bool;

        }
        #endregion

        #region Method
        public static void Save(int saveInt, string nameKey)
        {
            Int @int = new Int();
            @int.@int = saveInt;

            if (!Directory.Exists(Application.dataPath + "/Saves"))
                Directory.CreateDirectory(Application.dataPath + "/Saves");

            FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, @int);
            fs.Close();
        }

        public static void Load(ref int saveInt, string nameKey)
        {
            if (File.Exists(Application.dataPath + "/Saves/" + nameKey + ".sh"))
            {
                FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    Int @int = (Int)formatter.Deserialize(fs);
                    saveInt = @int.@int;
                }
                catch(System.Exception e)
                {
                    Debug.Log(e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                Debug.LogError("Ключа " + nameKey + " не существует");
                Application.Quit();
            }
        }

        public static void Save(float saveFloat, string nameKey)
        {
            Float @float = new Float();
            @float.@float = saveFloat;

            if (!Directory.Exists(Application.dataPath + "/Saves"))
                Directory.CreateDirectory(Application.dataPath + "/Saves");

            FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, @float);
            fs.Close();
        }

        public static void Load(ref float loadFloat, string nameKey)
        {
            if (File.Exists(Application.dataPath + "/Saves/" + nameKey + ".sh"))
            {
                FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    Float @float = (Float)formatter.Deserialize(fs);
                    loadFloat = @float.@float;
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                Debug.LogError("Ключа " + nameKey + " не существует");
                Application.Quit();
            }
        }

        public static void Save(double saveDouble, string nameKey)
        {
            Double @double = new Double();
            @double.@double = saveDouble;

            if (!Directory.Exists(Application.dataPath + "/Saves"))
                Directory.CreateDirectory(Application.dataPath + "/Saves");

            FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, @double);
            fs.Close();
        }

        public static void Load(ref double loadDouble, string nameKey)
        {
            if (File.Exists(Application.dataPath + "/Saves/" + nameKey + ".sh"))
            {
                FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    Double @double = (Double)formatter.Deserialize(fs);
                    loadDouble = @double.@double;
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                Debug.LogError("Ключа " + nameKey + " не существует");
                Application.Quit();
            }
        }

        public static void Save(string saveString, string nameKey)
        {
            String @string = new String();
            @string.@string = saveString;

            if (!Directory.Exists(Application.dataPath + "/Saves"))
                Directory.CreateDirectory(Application.dataPath + "/Saves");

            FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, @string);
            fs.Close();
        }

        public static void Load(ref string loadString, string nameKey)
        {
            if (File.Exists(Application.dataPath + "/Saves/" + nameKey + ".sh"))
            {
                FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    String @string = (String)formatter.Deserialize(fs);
                    loadString = @string.@string;
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                Debug.LogError("Ключа " + nameKey + " не существует");
                Application.Quit();
            }
        }

        public static void Save(bool saveBool, string nameKey)
        {
            Bool @bool = new Bool();
            @bool.@bool = saveBool;

            if (!Directory.Exists(Application.dataPath + "/Saves"))
                Directory.CreateDirectory(Application.dataPath + "/Saves");

            FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, @bool);
            fs.Close();
        }

        public static void Load(ref bool loadString, string nameKey)
        {
            if (File.Exists(Application.dataPath + "/Saves/" + nameKey + ".sh"))
            {
                FileStream fs = new FileStream(Application.dataPath + "/Saves/" + nameKey + ".sh", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                try
                {
                    Bool @bool = (Bool)formatter.Deserialize(fs);
                    loadString = @bool.@bool;
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                Debug.LogError("Ключа " + nameKey + " не существует");
                Application.Quit();
            }
        }
        #endregion
    }

    /*public class AD
    {
        public static bool isPlayed = Advertisement.isShowing;
        public static void Inicial(string GameId)
        {
            Advertisement.Initialize(GameId);
        }

        public static void ShowAd(string IdAdd)
        {
            if(Advertisement.isInitialized)
                Advertisement.Show(IdAdd);
        }
    }*/

    public class Time:MonoBehaviour
    {
        public static float Hourses, Minutes, Seconds;

        private float time;
        private bool play = true;


        public void StopwatchPlay()
        {
            if (play)
            {
                time+=UnityEngine.Time.deltaTime;
                Seconds = time % 60;
                Minutes = time / 60;
                Hourses = time / 3600;
            }
        }

        public void StopwatchStop()
        {
            play = false;
        }

        public void StopwatchReset()
        {
            time = 0;
        }

        public override string ToString()
        {
            string tim;
            tim = string.Format("{0:00}:{1:00}", (int)Minutes, (int)Seconds);
            return tim;
        }
    }

    public class Platform
    {
        public static bool PC, Android, IOS;
        
        public static string ReturnPlatform()
        {
#if UNITY_STANDALONE
            PC = true;
            Debug.Log("Windows");
            return "Windows";
#elif UNITY_ANDROID
            Android=true;
            Debug.Log("Andorid");
            return "Android";
#elif UNITY_IOS
            IOS=true;
            Debug.Log("IOS");
            return "IOS";
#endif
        }

    }

    public class ScoreSystem : MonoBehaviour
    {

        public static float Score;
        public static float MaxScore;

        public static void Inicial()
        {
            Score = 0;
            if (PlayerPrefs.HasKey("MaxScore"))
                MaxScore = PlayerPrefs.GetFloat("MaxScore");
            else MaxScore = 0;
        }


        public static void PlusScore()
        {
            Score++;
        }

        public static void UpdateMaxScore()
        {
            if (MaxScore < Score)
                MaxScore = Score;
        }

        public static void Save()
        {
            PlayerPrefs.SetFloat("MaxScore", MaxScore);
        }
    }


}
