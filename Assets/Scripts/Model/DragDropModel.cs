using UnityEngine;

public class DragDropModel 
{
    private float _rayLength = 50f;
    private float _height = 1.5f;
    private RaycastHit _hit;
    private BlockView _selectedBlock;

    private Camera _camera;

    public DragDropModel(Camera camera)
    {   
        _camera = camera;
    }

    public void ThrowRay(Vector3 transformPosition)
    {
        if (Physics.Raycast(transformPosition, MousePositionOffset(transformPosition), out _hit))
        {
            if (_hit.collider.TryGetComponent(out BlockView block) && _selectedBlock == null)
            {
                SelectBlock(block);
            }
        }
    }

    public void MoveBlock()
    {
        if (_selectedBlock == null)
            return;

        _selectedBlock.transform.position = new Vector3(_hit.point.x, _height, _hit.point.z);
    }

    public void GetSelectedBLock(out BlockView selectedBlock)
    {
        selectedBlock = _selectedBlock;
    }

    public void Drop()
    {
        _selectedBlock = null;
    }

    private void SelectBlock(BlockView block)
    {
        _selectedBlock = block;
    }

    private Vector3 MousePositionOffset(Vector3 transformPosition)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _rayLength;
        mousePosition = _camera.ScreenToWorldPoint(mousePosition);
        Vector3 mousePositionOffset = mousePosition - transformPosition;
        return mousePositionOffset;
    }
}
