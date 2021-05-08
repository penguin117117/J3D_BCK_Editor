# J3D_BCK_Editor
BCK_ファイルの編集を可能にするツールまだテストバージョンです。<br/>
このソフトを使うにはBCKファイルの知識が必要です。
## アップデート情報
全てのグラフが描画できるようになりました<br/>
少数の丸め込みの誤差がなくなりました。
## 使用方法_01(ファイルを開く)
ツールの使い方を説明します<br/>
まず既存のファイルを使うか使わないかによって使用方法が変わります。<br/>
今回は比較的簡単な既存のファイルを使用する方法を紹介します。<br/>
ファイル→開く　から既存のBCKファイルを開いてください。<br/>
![j3dbck01](https://user-images.githubusercontent.com/82487890/117532597-4d2beb80-b023-11eb-98a1-95cc1d8286ce.jpg)<br/><br/>
ファイルを開くとチャンクヘッダー設定と<br/>
4つのテーブル(アニメーション、スケール、ローテート、トランスレート)に値が入ります。<br/>
![j3dbck02](https://user-images.githubusercontent.com/82487890/117532680-ad229200-b023-11eb-9555-13b2cb905351.jpg)<br/><br/>
これらの値を編集することでアニメーションを制御できます。<br/><br/>
## 使用方法_02(チャンクヘッダー)
チャンクヘッダーはあまり触らないことをお勧めします。
### ループモード
<table>
<thead>
<tr>
<th>モード名</th>
<th>モード番号</th>
  <th>説明</th>
</tr>
</thead>
<tbody>
<tr>
<td>一回のみ</td>
<td>0</td>
  <td>アニメーションが最終のフレームで停止</td>
</tr>
<tr>
<td>一回のみ</td>
<td>1</td>
  <td>アニメーションが最初のフレームで停止</td>
</tr>
  <tr>
<td>ループ</td>
<td>2</td>
    <td>アニメーションがループします</td>
</tr>
  <tr>
<td>一回のみミラー</td>
<td>3</td>
    <td>アニメーションが最初から最後まで再生されその後最初のフレームまで戻って停止</td>
</tr>
  <tr>
<td>ミラーループ</td>
<td>4</td>
    <td>一回ミラーのアニメーションをループします</td>
</tr>
</tbody>
<tfoot>
<tr>
<td>エラー</td>
<td>それ以外の値</td>
  <td>-1<値<5 である必要がります。それ以外の場合エラーです </td>
</tr>
</tfoot>
</table>

### 回転倍率
これも触らないほうがいい値です<br/>
回転のタンジェントの値を調整します(tan × 10^値)<br/>
具体的には不明ですが一応この機能も使うことが出来ます。

### フレーム数
アニメーションのトータルのフレーム数

### ジョイント数
ボーンのジョイントの数です


## 使用方法(グラフ)
ファイルを読み込んだ場合グラフタブのコンボボックスを選択すると<br/>
選択されたジョイントの値をグラフに表示します。<br/>
ジョイントの制御は3Dモデルのアニメーションの知識が必要になりますが<br/>
適当にいじっても案外何とかなるので適当にいじってみましょう。<br/>
