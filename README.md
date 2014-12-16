AssemblyDiscovery
=================

[![AppVeyor](http://img.shields.io/appveyor/ci/patrinhani-ciandt/assemblydiscovery.svg?style=flat-square)](https://ci.appveyor.com/project/patrinhani-ciandt/assemblydiscovery)
[![MyGet](http://img.shields.io/myget/bohriumnet/v/AssemblyDiscovery.svg?style=flat-square&label=AssemblyDiscovery)](https://www.myget.org/F/bohriumnet/)

<h1>Usage Examples</h1>

<h2>Report Generator</h2>
<h3>Command Line Examples</h3>
/>AssemblyDiscovery45.exe "SampleProject.ConsoleApp.exe" -r -o:html "SampleProject.ConsoleApp-rep.html"

/>AssemblyDiscovery45.exe "SampleProject.ConsoleApp.exe" -o:html "SampleProject.ConsoleApp-rep.html"

/>AssemblyDiscovery45.exe "SampleProject.ConsoleApp.exe" -o:txt "SampleProject.ConsoleApp-rep.txt"

<h2>Assembly References Validation</h2>

XML Validation Input Example:
SampleProject.ConsoleApp-val.xml
<pre><code>
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;AssemblyValidator xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;
  &lt;ValidatorDefinitions&gt;
    &lt;References&gt;
	  &lt;!--  Version Less Than or Equal 3.0.0.0 --&gt;
      &lt;ValidatorDefinitionReference AssemblyName=&quot;mscorlib&quot; Version=&quot;-=3.0.0.0&quot; Allowed=&quot;false&quot; ErrorType=&quot;Warning&quot; /&gt;
	  &lt;!--  Version Greater Than or Equal 1.2.13.0 --&gt;
      &lt;ValidatorDefinitionReference AssemblyName=&quot;log4net&quot; Version=&quot;+=1.2.13.0&quot; Required=&quot;true&quot; ErrorType=&quot;Error&quot; /&gt;
      &lt;ValidatorDefinitionReference AssemblyName=&quot;NHibernate&quot; Version=&quot;3.0.*.0&quot; Allowed=&quot;true&quot; ErrorType=&quot;Error&quot; /&gt;
      &lt;ValidatorDefinitionReference AssemblyName=&quot;System.Web&quot; Version=&quot;*&quot; Allowed=&quot;false&quot; ErrorType=&quot;Error&quot; /&gt;
      &lt;ValidatorDefinitionReference AssemblyName=&quot;SampleProject.ClassLib01&quot; Version=&quot;=1.0.0.0&quot; Allowed=&quot;true&quot; ErrorType=&quot;Error&quot; /&gt;
    &lt;/References&gt;
  &lt;/ValidatorDefinitions&gt;
&lt;/AssemblyValidator&gt;
</code></pre>

<h3>Command Line Examples</h3>
/>AssemblyDiscovery45.exe "SampleProject.ConsoleApp.exe" -v "SampleProject.ConsoleApp-val.xml"
