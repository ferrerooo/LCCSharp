// https://leetcode.com/problems/triangle/

using System;
using System.Collections.Generic;

public class Solution120 {
    public int MinimumTotal(IList<IList<int>> triangle) {
        
        var layer = triangle.Count - 1;
        
        var lowerLayerSum = new List<int>();
        var upperLayerSum = new List<int>();
        
        foreach (var i in triangle[layer])
            lowerLayerSum.Add(i);
        
        layer = layer - 1;
        
        while (layer >= 0) {
            
            var currentLayer = triangle[layer];
            
            for (int i = 0; i <= layer; i++) {
                
                var minPath = Math.Min(currentLayer[i] + lowerLayerSum[i],
                                   currentLayer[i] + lowerLayerSum[i+1]);
                
                upperLayerSum.Add(minPath);
            }
            
            lowerLayerSum = upperLayerSum;
            upperLayerSum = new List<int>();
            layer = layer - 1;
            
        }
        
        return lowerLayerSum[0];
    }
}