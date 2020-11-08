using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Extensions
{
	public static class Ext
	{

	}

	public static class MathExt
	{
		public static int RoundOff(int number, int interval)
		{
			return ((int)Math.Round(number / (float)interval)) * interval;
		}
	}

	public static class UIExt
    {
	    public static void Reset()
        {
            Debug.LogWarning("Reset Scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

	    public static void Quit()
        {
            Debug.LogWarning("Quit");
            Application.Quit();
        }

	    public static void OnClickButton()
        {

        }
    }

	public static class ListExt
	{
        /*Preforms Fisher–Yates shuffle on list*/
        public static List<T> Shuffle<T>(List<T> list)
        {
            int length = list.Count - 2;
            for (int index = 0; index < length; index++)
            {
                int newIndex = UnityEngine.Random.Range(index, length);
                Swap(list, index, newIndex);
            }
            return list;
        }

        public static void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

		public static bool IsEqual<T>(List<T> listA, List<T> listB)
		{
			if (listA != null && listB != null && listA.Count == listB.Count)
			{
				if (listA.Count == 0)
				{
					return true;
				}

				for (int i = 0; i < listA.Count; i++)
				{
					if (!listA[i].Equals(listB[i]))
					{
						return false;
					}
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void PrintList<T>(List<T> list)
		{
			foreach (T item in list)
			{
				Debug.Log("" + item);
			}
		}

	}	

}





