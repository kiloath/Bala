Excel 呼叫函式庫
================
# {1!} 關於
* 使用Visual Studio 2022
* 使用Conan
# {2!} 使用Visual Studio 2022
## {2.1!} 說明 
* 開發DLL函式庫
* 建立Excel呼叫函式庫
## {2.2!} 開發DLL函式庫
* 工具: Visual Studio 2022
* 建立專案:
  * square.cpp
  * deffile.def
## {2.3!} 建立Excel呼叫函式庫
* 建立Excel, 存為xslm
* 材料:
  * Module1.bas
  * ThisWorkbook.cls
# {3!} 使用Conan
## {3.1!} 說明
* 指令
```
ni squareDll2 -i "d"
cd squredll
conan new cmake_lib -d name=squaredll -d version=1.0
conan create .

```