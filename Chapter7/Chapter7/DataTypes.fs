module DataTypes

open System.Drawing


type rect =
    {
        Left    : float32
        Top     : float32
        Width   : float32
        Height  : float32
    }

type TextContent =
    { Text : string
      Font : Font}
type ScreenElement =
    | TextElement of TextContent * rect
    | ImageElement of string * rect    // image filename
    
    
module Rect =
    let deflate (original,wspace,hspace) =
        {
            Left = original.Left + wspace
            Top = original.Top + hspace
            Width = original.Width - (2.0f * wspace)
            Height = original.Height - (2.0f * hspace)
        }
    
    let toRectangleF (original) =
        RectangleF(original.Left,original.Top,original.Width,original.Height)