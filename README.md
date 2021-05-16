# J3D_BCK_Editor
BCKファイルの編集を可能にするツール<br/>
このソフトを使うにはBCKファイルの知識が必要です。
## アップデート情報
全てのグラフが描画できるようになりました<br/>
少数の丸め込みの誤差がなくなりました。
## 使用方法
<details>
<summary>ファイルを開く・・・</summary>
ツールの使い方を説明します<br/>
より詳しい解説は下記URL<br/>
http://mariogalaxy2hack.wiki.fc2.com/wiki/J3D_BCK_Editor<br/>
まず既存のファイルを使うか使わないかによって使用方法が変わります。<br/>
今回は比較的簡単な既存のファイルを使用する方法を紹介します。<br/>
ファイル→開く　から既存のBCKファイルを開いてください。<br/>
  
![j3dbck01](https://user-images.githubusercontent.com/82487890/117532597-4d2beb80-b023-11eb-98a1-95cc1d8286ce.jpg)<br/><br/>

ファイルを開くとチャンクヘッダー設定と<br/>
4つのテーブル(アニメーション、スケール、ローテート、トランスレート)に値が入ります。<br/>

![j3dbck02](https://user-images.githubusercontent.com/82487890/117532680-ad229200-b023-11eb-9555-13b2cb905351.jpg)<br/><br/>

これらの値を編集することでアニメーションを制御できます。<br/><br/>

</details>
<hr/>
<details>
<summary>チャンクヘッダー・・・</summary>
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

</details>
<hr/>
<details>
<summary>アニメーションテーブル・・・</summary>

この項目がかなり重要ですここを理解できないと他のテーブルを上手く制御できません。
<table>
<thead>
<tr>
<th>ボーン数(ジョイントの数)</th>
<th>XYZステータス</th>
  <th>フレーム数</th>
  <th>開始テーブル番号</th>
  <th>タンジェントモード</th>
</tr>
</thead>
<tbody>
<tr>
<td>ジョイントの番号</td>
<td>倍率、回転、位置(x,y,z)のどれかが分かる</td>
  <td>キーフレームの数</td>
  <td>開始テーブル番号</td>
  <td>タンジェントのパスコントローラーの値1と値2が一緒かどうか</td>
</tr>
</tbody>

</table>

<details>
<summary>フレーム数が1の場合・・・</summary>

![j3dbck03](https://user-images.githubusercontent.com/82487890/117533772-9a12c080-b029-11eb-8c21-2edb7377961f.jpg)<br/>
上図のようにフレーム数が1の場合はアニメーションは<br/>
最初から最後まで同じで、1つのテーブルの値を参照します。<br/>
今回のケースの場合は下図の選択された値を参照します。<br/>
![j3dbck04](https://user-images.githubusercontent.com/82487890/117533905-1ad1bc80-b02a-11eb-893c-c1d8eeb5204a.jpg)<br/>
スケールテーブルのテーブル番号0の値を一つ参照今回の場合値は「1」。<br/>
グラフは下図のような直線のグラフになります。(青色の線)
![j3dbck05](https://user-images.githubusercontent.com/82487890/117534071-d8f54600-b02a-11eb-9da5-ecaee600d236.jpg)<br/>

</details>
<details>
<summary>フレーム数が2以上でタンジェントモードが0の場合・・・</summary>
このケースの場合1フレームにつき3つの値を参照します。
  
![j3dbck06](https://user-images.githubusercontent.com/82487890/117534201-5d47c900-b02b-11eb-86f9-a9f9c7f09dba.jpg)<br/>
上図のようにフレーム数が2以上でタンジェントモードが0の場合は<br/>
曲線のグラフでパスコントロールの値1と値2が同じです。(ホワイトホールパスのイメージです)<br/>
今回のケースの場合は下図の選択された値を参照します。<br/>

![j3dbck07](https://user-images.githubusercontent.com/82487890/117534338-ebbc4a80-b02b-11eb-9542-ed2144491e91.jpg)<br/>
今回の場合ローテートテーブルのテーブル番号1から12(4フレーム × 3)の値を参照します。<br/>
<table>
  <caption>3つの値解説(上図の4データのうち1つ抜き出し)</caption>
<thead>
<tr>
<th>値名</th>
<th>テーブル番号</th>
  <th>値</th>
</tr>
</thead>
<tbody>
<tr>
<td>キーフレーム番号</td>
  <td>1</td>
<td>0</td>
  </tr>
  <tr>
  <td>回転値(度数法)</td>
  <td>2</td>
<td>0.0000000000</td>
  </tr>
  <tr>
  <td>タンジェント</td>
  <td>3</td>
<td>-227</td>
</tr>
</tbody>
</table>
今回のデータの場合グラフは下図のようになります。<br/>

![j3dbck08](https://user-images.githubusercontent.com/82487890/117535156-7a7e9680-b02f-11eb-943a-79bcaa0dd343.jpg)

<br/>
</details>

<details>
<summary>フレーム数が2以上でタンジェントモードが1の場合・・・</summary>
このケースの場合は4つの値を取ります。<br/>
四つの値は上から順に<br/>
フレーム、値、コントロール1のタンジェント、コントロール2のタンジェントです。
</details>

</details>
<hr/>

<details>
<summary>スケールテーブルとトランスレートテーブル・・・</summary>
<br/>
スケールテーブルはジョイントのサイズを<br/>
設定する項目です1.0がデフォルトの値です。<br/>
  トランスレートテーブルはジョイントの位置を<br/>
設定する項目です0.0がデフォルトの値です。<br/>
アニメーションテーブルのスケールX,Y,Z(または、トランスレートX,Y,Z)の値を参照して<br/>
アニメーションテーブルの<br/>
  フレーム数、開始フレーム番号、タンジェントモードの値を使用して<br/>
読み取り方法を決定しています。<br/><br/>
  <table>
    <caption>フレーム数が1の場合</caption>
<thead>
<tr>
<th>テーブル番号</th>
<th>数値</th>
</tr>
</thead>
<tbody>
<tr>
<td>スケール、トランスレートの値</td>
<td>位置の値(Folat型)</td>
</tr>
</tbody>
</table>
  
  <br/>
  <table>
    <caption>フレーム数が2以上でタンジェントモードが0の場合</caption>
<thead>
<tr>
<th>テーブル番号</th>
<th>数値</th>
</tr>
</thead>
<tbody>
<tr>
<td>キーフレーム番号</td>
<td>値(Folat型)</td>
</tr>
  <tr>
<td>スケール、トランスレートの値</td>
<td>値(Folat型)</td>
</tr>
  <tr>
<td>タンジェントの値</td>
<td>値(Folat型)</td>
</tr>
</tbody>
</table>
  
  <br/>
  <table>
    <caption>フレーム数が2以上でタンジェントモードが1の場合</caption>
<thead>
<tr>
<th>テーブル番号</th>
<th>数値</th>
</tr>
</thead>
<tbody>
<tr>
<td>キーフレーム番号</td>
<td>値(Folat型)</td>
</tr>
  <tr>
<td>スケール、トランスレートの値</td>
<td>値(Folat型)</td>
</tr>
  <tr>
<td>タンジェントの値1</td>
<td>値(Folat型)</td>
</tr>
   <tr>
<td>タンジェントの値2</td>
<td>値(Folat型)</td>
</tr>
</tbody>
</table>
  
  </details>
<hr/>

<details>
<summary>グラフ・・・</summary>
ファイルを読み込んだ場合グラフタブのコンボボックスを選択すると<br/>
選択されたジョイントの値をグラフに表示します。<br/>
ジョイントの制御は3Dモデルのアニメーションの知識が必要になりますが<br/>
適当にいじっても案外何とかなるので適当にいじってみましょう。<br/>
  </details>
<hr/>
