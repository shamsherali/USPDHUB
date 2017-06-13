#collect the parameters
param($installPath, $toolsPath, $package, $project)


#create a temporary function to add a solutions directory named .nuget
function Add-SolutionFolder {
    param(
       [string]$Name
    )
    $solution2 = Get-Interface $dte.Solution ([EnvDTE80.Solution2])
    $solution2.AddSolutionFolder($Name)
}


function Resolve-ProjectName {
    param(
        [parameter(ValueFromPipelineByPropertyName = $true)]
        [string[]]$ProjectName
    )
    
    if($ProjectName) {
        $projects = Get-Project $ProjectName
    }
    else {
        # All projects by default
        $projects = Get-Project -All
    }
    
    $projects
}

function Get-MSBuildProject {
    param(
        [parameter(ValueFromPipelineByPropertyName = $true)]
        [string[]]$ProjectName
    )
    Process {
        (Resolve-ProjectName $ProjectName) | % {
            $path = $_.FullName
            @([Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($path))[0]
        }
    }
}

function Add-Import {
    param(
        [parameter(Position = 0, Mandatory = $true)]
        [string]$Path,
        [parameter(Position = 1, ValueFromPipelineByPropertyName = $true)]
        [string[]]$ProjectName
    )
    Process {
        (Resolve-ProjectName $ProjectName) | %{
            $buildProject = $_ | Get-MSBuildProject
            $buildProject.Xml.AddImport($Path)
            $_.Save()
        }
    }
}
$mypath = $installPath
$mypath = $mypath.SubString(0,($mypath.LastIndexOf('\')+1))
$mypath = $mypath -replace ".$" 
$mypath = $mypath.SubString(0,($mypath.LastIndexOf('\')+1)) 
$nupath1 = $mypath + ".nuget"

$tvar = Test-Path $nupath1 -pathType container
"executed test path" | out-file "c:\demo\eviro.txt"
$tvar | out-file "c:\demo\eviro.txt" -append
if($tvar -eq $false)
{

# $installPath | out-file "c:\demo\eviro.txt"
# $toolsPath | out-file "c:\demo\eviro.txt" -append

md $nupath1

$confg = $toolsPath + "\Nuget.config"
$nexe = $toolsPath + "\Nuget.exe"
$ntarg = $toolsPath + "\Nuget.targets"

copy $confg $nupath1
copy $nexe $nupath1
copy $ntarg $nupath1

$mypath | out-file "c:\demo\eviro.txt" -append
$confg | out-file "c:\demo\eviro.txt" -append
$nexe | out-file "c:\demo\eviro.txt" -append
$ntarg | out-file "c:\demo\eviro.txt" -append
$nupath1 | out-file "c:\demo\eviro.txt" -append


$sf = Add-SolutionFolder .nuget

$SolutionDir | out-file "c:\demo\eviro.txt" -append

$a1 = $mypath + ".nuget\Nuget.Config"
$a2 = $mypath + ".nuget\Nuget.exe"
$a3 = $mypath + ".nuget\Nuget.targets"

$a1 | out-file "c:\demo\eviro.txt" -append
$a2 | out-file "c:\demo\eviro.txt" -append
$a3 | out-file "c:\demo\eviro.txt" -append

$sf.ProjectItems.AddFromFile($a1)
$sf.ProjectItems.AddFromFile($a2)
$sf.ProjectItems.AddFromFile($a3)


"Hello before Get-project" | out-file "c:\demo\eviro.txt" -append

Get-Project -All  | out-file "c:\demo\eviro.txt" -append
 
Get-Project -All | Add-Import '$(SolutionDir)\.nuget\Nuget.targets'


"AFTER Get-project" | out-file "c:\demo\eviro.txt" -append
}
