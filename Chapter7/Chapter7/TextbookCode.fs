module TextbookCode

open System.Drawing
open DataTypes
open DataTypes.Rect

let rc = {
    Left = 10.0f;
    Top = 10.0f;
    Width = 100.0f;
    Height = 200.0f;
    }
    
let rc2 = {rc with Left = rc.Left + 100.0f}

let it1 = {Left = 0.0f; Top = 0.0f; Width = 100.0f; Height = 100.0f}

let it2 = Rect.deflate(it1,20.0f,10.0f)

//////////////////////////////////////////

let fntText = new Font("Calibri", 12.0f)
let fntHead = new Font("Calibri", 15.0f)

let imageFilePath = 
    "C:\Users\chang\Desktop\ProgrammingTest\FSharp Book Learning\FSharp-Self-Learning\Chapter7\BookImage.jpg"

let elements =
    [ TextElement
        ({  Text = "Functional Programming for the Real World"
            Font = fntHead},
         {  Left = 10.0f; Top = 0.0f; Width = 410.0f; Height = 30.0f});
      ImageElement
        (imageFilePath,
         {Left = 120.0f; Top = 30.0f; Width = 150.0f; Height = 200.0f});
      TextElement 
        ({ Text = 
               "In this book, we'll introduce you to the essential " +
               "concepts of functional programming, but thanks to the .NET " +
               "Frameowrk, we won't be limited to theoretical examples. " +
               "We'll use many of the rick .NET libraries to show how " +
               "functional programming can by used in the real world."
           Font = fntText },
           {Left = 10.0f; Top = 230.0f; Width = 400.0f; Height = 400.0f})
    ]

let drawElements elements (gr:Graphics) =
    elements
    |> List.iter (fun p ->
        match p with
        | TextElement(text,boundingBox) ->
            let boxf = DataTypes.Rect.toRectangleF(boundingBox)
            gr.DrawString(text.Text, text.Font, Brushes.Black, boxf)
        | ImageElement(imagePath, boundingBox) ->
            let bmp = new Bitmap(imagePath)
            let wspace, hspace = 
                boundingBox.Width / 10.0f, boundingBox.Height / 10.0f
            let rc = toRectangleF(deflate(boundingBox,wspace,hspace))
            gr.DrawImage(bmp,rc)
    )










