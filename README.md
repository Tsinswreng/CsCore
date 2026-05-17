## Tsinswreng.CsCore

Tsinswreng.CsCore 是一個極薄的 C# 基礎抽象庫。

它提供的不是完整框架能力，而是一組可被上層公共庫反覆複用的最小約定：

- 全局類型別名
- 極小型接口
- 輕量標註 Attribute
- 少量常用擴展方法

它適合作爲整組 `Tsinswreng.*` 庫的底層依賴，也適合在你自己的值對象、強類型 ID、通用工具庫中作爲最小公共內核。

### 安裝

```bash
dotnet add package Tsinswreng.CsCore --version 0.0.1-alpha
```

### 目標框架

當前包多目標爲：

- `netstandard2.0`
- `net10.0`

### 內容概覽

#### 全局類型別名

此庫提供了一組偏簡寫風格的全局別名，例如：

- `u8`
- `i32`
- `u64`
- `f32`
- `f64`
- `str`
- `obj`
- `nil`
- `CT`

它們對應到標準 .NET 類型，例如 `System.Byte`、`System.Int32`、`System.String`、`CancellationToken` 等。

#### 值對象相關接口

- `I_ValueObj`
- `I_Value<T>`
- `I_ToSerialized`
- `I_ToDeSerialized`
- `IRawValueSerializable`

這組接口主要用來支持：

- 強類型 ID
- 值對象
- 按裸值進行序列化/反序列化的包裝類型

例如你不希望某個值對象被序列化成 `{"Value": 123}`， 而是希望直接表現爲 `123` 或 `"abc"` 時，就可以圍繞這組接口構建自己的轉換器協議。

#### 其他輕量接口

- `I_Init`
- `I_ShallowCloneSelf`

它們分別用來表達：

- 一個對象可執行初始化步驟
- 一個對象可提供淺拷貝語義

#### Attribute

- `Doc`
- `Impl`
- `DoNotRename`
- `DoNotRenameMembers`

這些 Attribute 更偏向代碼組織、文檔標註和重構約束，而不是運行時框架能力。

#### 擴展方法

此庫還提供少量通用擴展方法，例如：

- `AddRange`
- `Sort(Comparison<T>)`
- `AsOrToList`
- `EqObj`
- 若干 enum 比較輔助
- `IDictionary<K, V>.GetValueOrDefault`
- `ExtnNumber.AsI32`

在較新目標框架下，還包含 `IAsyncEnumerable<T>` 相關的輔助。

### 示例

#### 值對象接口

```csharp
using Tsinswreng.CsCore;

public record struct UserId : I_Value<long> {
	public long Value { get; set; }
}
```

#### 集合輔助

```csharp
using Tsinswreng.CsCore;

var list = new List<int>();
list.AddRange([1, 2, 3]);
```

#### 按比較器排序

```csharp
using Tsinswreng.CsCore;

var xs = new List<int>{ 3, 1, 2 };
xs.Sort((a, b) => a - b);
```

#### 字典取默認值

```csharp
using Tsinswreng.CsCore;

IDictionary<string, int> dict = new Dictionary<string, int>();
var value = dict.GetValueOrDefault("missing", 0);
```

### 設計定位

CsCore 應保持很薄。

適合放在這裏的東西通常同時滿足：

- 對很多上層程序集都通用
- 只依賴 BCL 或非常穩定的語言級抽象
- 不綁定具體框架、資料庫、UI 或序列化實現

若某個工具只服務某個子領域，或者已經開始帶有明顯框架語義， 更適合拆去單獨的小包，而不是繼續堆進 `CsCore`。

### 適用場景

- 作爲多個自研庫共享的最底層抽象
- 爲值對象和強類型 ID 提供最小公共接口
- 爲整個代碼倉提供統一的簡寫類型別名與標註風格

### v0.0.1-alpha

- 初始 alpha 版本
- 提供類型別名、值對象接口、輕量 Attribute 與少量通用擴展方法
