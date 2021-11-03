using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banks
{
    /// <summary>
    /// Модификатор текста
    /// </summary>
    class _TextsModifier
    {
        /// <summary>
        /// Удалить все заданные строки из RichTextBox
        /// </summary>
        /// <param name="deletes">Удаляемые строки</param>
        /// <param name="RTB_Result">Изменяемый RichTextBox</param>
        public void ClearAllByText(List<string> deletes, ref RichTextBox RTB_Result)
        {
            for (int i = 0; i < deletes.Count; i++)
            {
                RTB_Result.Text = RTB_Result.Text.Replace(deletes[i], "");
            }
        }
        /// <summary>
        /// Изменить текст согласно заданным тегам(внутри функции)
        /// </summary>
        /// <param name="str">Изменяемая строка</param>
        /// <param name="RTB_Result">Изменяемый RichTextBox</param>
        public void ModifyByTag(string str, ref RichTextBox RTB_Result)
        {
            // Листы открывающих и закрывающих индексов изменения
            List<int> Open_Indexes = new List<int>();
            List<int> Close_Indexes = new List<int>();
            // Шрифты для изменения текста
            List<Font> Fonts = new List<Font>();
            // Листы открывающих и закрывающих тегов
            List<string> TagsOpen = new List<string>();
            List<string> TagsClose = new List<string>();
            TagsOpen.AddRange(new string[] { "<b>", "<u>", "<ub>" });
            TagsClose.AddRange(new string[] { "</b>", "</u>", "</ub>" });

            // Открытый и закрытый текущий тег
            string tagopen;
            string tagclose;

            // Пройти по всем тегам
            for (int i = 0; i < TagsOpen.Count; i++)
            {
                // Пока имеется хотя бы один открывающий тег
                while (str.Contains(TagsOpen[i]))
                {
                    tagopen = TagsOpen[i];
                    tagclose = TagsClose[i];
                    // Добавить в список открывающих тегов нужный индекс
                    Open_Indexes.Add(str.IndexOf(tagopen));
                    // Добавить в список закрывающих тегов нужный индекс
                    Close_Indexes.Add(str.IndexOf(tagclose) - tagclose.Length + 1);

                    if (tagopen == "<b>") Fonts.Add(new Font(RTB_Result.Font.FontFamily, RTB_Result.Font.Size, FontStyle.Bold));
                    else if (tagopen == "<u>") Fonts.Add(new Font(RTB_Result.Font.FontFamily, RTB_Result.Font.Size, FontStyle.Italic));
                    else if (tagopen == "<ub>") Fonts.Add(new Font(RTB_Result.Font.FontFamily, RTB_Result.Font.Size, FontStyle.Bold | FontStyle.Italic));

                    // Убрать из текста добавленные теги
                    str = str.Remove(str.IndexOf(tagopen), tagopen.Length);
                    str = str.Remove(str.IndexOf(tagclose), tagclose.Length);

                    for (int j = 0; j < Open_Indexes.Count; j++)
                    {
                        if (Open_Indexes[Open_Indexes.Count - 1] < Open_Indexes[j])
                        {
                            Open_Indexes[j] -= tagopen.Length + tagclose.Length;
                            Close_Indexes[j] -= tagclose.Length + tagclose.Length - 1;
                        }
                    }
                }
            }
            // Добавить исходный текст в результирующий RichTextBox
            RTB_Result.Text = str;
            // Пройтись по списку открывающих тегов
            for (int i = 0; i < Open_Indexes.Count; i++)
            {
                // Снять любые выделения
                RTB_Result.DeselectAll();
                // Выделить текст по открывающему и закрывающему тегам
                RTB_Result.Select(Open_Indexes[i], Close_Indexes[i] - Open_Indexes[i]);
                // Поменять шрифт у выделенного текста
                RTB_Result.SelectionFont = Fonts[i];
            }
            RTB_Result.DeselectAll();
        }
    }
}
