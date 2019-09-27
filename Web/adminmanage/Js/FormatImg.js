function FormatImg(W,H,Id)
{
    ImgId = document.getElementById(Id);
    var image=new Image();
    image.src = ImgId.src;
    if(image.width>0 && image.height>0)
    {
        if(image.width/image.height>= W/H)
        {
            if(image.width>W)
            {
                ImgId.width=W;
                ImgId.height=(image.height*W)/image.width;
            }
            else
            {
                ImgId.width=image.width;
                ImgId.height=image.height;
            }
        }
        else
        {
            if(image.height>H)
            {
                ImgId.height=H; 
                ImgId.width=(image.width*H)/image.height; 
            }
            else
            {
                ImgId.width=image.width; 
                ImgId.height=image.height; 
            }
        }
    }
}
