using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppTask.Server.Enums;
using System.Linq;

namespace WebAppTask.Server.Helper;

public class SortHelper
{
    public async Task<List<string>> Sort(List<string> items, SortType sortType)
    {
        List<string> result = new List<string>();
        switch (sortType)
        {
            case SortType.Normal:
                result = items;
                break;
            case SortType.Ask:
                result = await SortAsk(items);
                break;
            case SortType.Desc:
                result = await SortDesc(items);
                break;
            case SortType.Reverse:
                result = await SortReverse(items);
                break;
            default:
                throw new ArgumentException("Нет такого типа сортировки");
        }
        return result;
    }

    public async Task<List<string>> SortAsk(List<string> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            for (int j = 0; j < inputList.Count - i - 1; j++)
            {
                if (Compare(inputList[j], inputList[j + 1]) > 0)
                {
                    Swap(inputList, j, j + 1);
                }
            }
        }
        await Task.CompletedTask;
        return inputList;
    }

    public async Task<List<string>> SortDesc(List<string> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            for (int j = 0; j < inputList.Count - i - 1; j++)
            {
                if (Compare(inputList[j], inputList[j + 1]) < 0)
                {
                    Swap(inputList, j, j + 1);
                }
            }
        }
        await Task.CompletedTask;
        return inputList;
    }

    public async Task<List<string>> SortReverse(List<string> inputList)
    {
        int left = 0;
        int right = inputList.Count - 1;
        while (left < right)
        {
            Swap(inputList, left, right);
            left++;
            right--;
        }
        await Task.CompletedTask;
        return inputList;
    }

    private int Compare(string a, string b)
    {
        string lowerA = a.ToLower();
        string lowerB = b.ToLower();

        if (int.TryParse(lowerA, out int numA) && int.TryParse(lowerB, out int numB))
        {
            return numA.CompareTo(numB);
        }
        else
        {
            return string.Compare(lowerA, lowerB, StringComparison.Ordinal);
        }
    }
    private void Swap(List<string> list, int index1, int index2)
    {
        string temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}
