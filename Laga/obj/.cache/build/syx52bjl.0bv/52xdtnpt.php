<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class IODataFolder
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class IODataFolder
   ">
    <meta name="generator" content="docfx 2.59.0.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="../toc.html">
    <meta property="docfx:tocrel" content="toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="Laga.IO.IODataFolder">
  
  
  <h1 id="Laga_IO_IODataFolder" data-uid="Laga.IO.IODataFolder" class="text-break">Class IODataFolder
  </h1>
  <div class="markdown level0 summary"><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="2">Get Data files information from a folder directory</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">IODataFolder</span></div>
  </div>
  <div class="inheritedMembers">
    <h5>Inherited Members</h5>
    <div>
      <span class="xref">System.Object.ToString()</span>
    </div>
    <div>
      <span class="xref">System.Object.Equals(System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.Equals(System.Object, System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.ReferenceEquals(System.Object, System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.GetHashCode()</span>
    </div>
    <div>
      <span class="xref">System.Object.GetType()</span>
    </div>
    <div>
      <span class="xref">System.Object.MemberwiseClone()</span>
    </div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="Laga.IO.html">Laga.IO</a></h6>
  <h6><strong>Assembly</strong>: Laga.dll</h6>
  <h5 id="Laga_IO_IODataFolder_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class IODataFolder</code></pre>
  </div>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="Laga_IO_IODataFolder__ctor_" data-uid="Laga.IO.IODataFolder.#ctor*"></a>
  <h4 id="Laga_IO_IODataFolder__ctor_System_String_" data-uid="Laga.IO.IODataFolder.#ctor(System.String)">IODataFolder(String)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="2">The Object to extract data from the folder</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public IODataFolder(string PathFolder)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">PathFolder</span></td>
        <td><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="1">The folders path to analize</p>
</td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="Laga_IO_IODataFolder_ListFileNames_" data-uid="Laga.IO.IODataFolder.ListFileNames*"></a>
  <h4 id="Laga_IO_IODataFolder_ListFileNames" data-uid="Laga.IO.IODataFolder.ListFileNames">ListFileNames</h4>
  <div class="markdown level1 summary"><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="2">The list of file names without extension</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public string[] ListFileNames { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.String</span>[]</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Laga_IO_IODataFolder_ListPathFileNames_" data-uid="Laga.IO.IODataFolder.ListPathFileNames*"></a>
  <h4 id="Laga_IO_IODataFolder_ListPathFileNames" data-uid="Laga.IO.IODataFolder.ListPathFileNames">ListPathFileNames</h4>
  <div class="markdown level1 summary"><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="2">The List of file names including the path</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public string[] ListPathFileNames { get; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.String</span>[]</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Laga_IO_IODataFolder_RootFolder_" data-uid="Laga.IO.IODataFolder.RootFolder*"></a>
  <h4 id="Laga_IO_IODataFolder_RootFolder" data-uid="Laga.IO.IODataFolder.RootFolder">RootFolder</h4>
  <div class="markdown level1 summary"><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="2">The Roof folder with the files</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public string RootFolder { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="Laga_IO_IODataFolder_ReadSelectiveData_" data-uid="Laga.IO.IODataFolder.ReadSelectiveData*"></a>
  <h4 id="Laga_IO_IODataFolder_ReadSelectiveData_System_String_" data-uid="Laga.IO.IODataFolder.ReadSelectiveData(System.String)">ReadSelectiveData(String)</h4>
  <div class="markdown level1 summary"><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="2">The List of files according to the specified extension</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public List&lt;string&gt; ReadSelectiveData(string extension)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">extension</span></td>
        <td><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="1">The extension file to filter: &quot;.txt&quot;</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">System.String</span>&gt;</td>
        <td><p sourcefile="api/Laga.IO.IODataFolder.yml" sourcestartlinenumber="1">List</p>
</td>
      </tr>
    </tbody>
  </table>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
                <h5>In This Article</h5>
                <div></div>
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>
