Function Convert-TableOfContentsTxtToMd {
  [CmdletBinding()]
  param()
  Read-Content .\TOC.md | ?{ 
    $_ -match '(?<Chapter>\d*)(?<Topic>.*?)(?<PageNumber>\d*)?$' } | %{
      $pageNumber = if($Matches.ContainsKey("PageNumber")){$Matches.PageNumber}
      $chapter = if($Matches.ContainsKey("Chapter")){$Matches.Chapter}
      [hashtable]@{ Chapter=$Chapter; Topic=$matches.Topic; PageNumber=$PageNumber }   } | %{
        "$(if($Chapter){"## $Chapter. "}else{"* "}) $($matches.topic)"  
  }
}
Convert-TableOfContentsTxtToMd